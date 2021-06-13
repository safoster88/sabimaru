namespace Sabimaru.Tests.Entities
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using FluentAssertions;
	using FluentAssertions.Execution;
	using Sabimaru.Entities;
	using Xunit;

	public class WhenCreatingMultipleEntities : TestBase
	{
		private readonly List<CreateEntityRequest> requests = new() { new(), new(), new() };
		private readonly List<int> responses = new();

		[Fact]
		public async Task ThenTheResultantEntitiesShouldHaveNumericallyAscendingIds()
		{
			await SendRequests();

			using var _ = new AssertionScope();
			
			for (var i = 0; i < responses.Count; i++)
			{
				responses[i].Should().Be(i);
			}
		}
		
		private async Task SendRequests()
		{
			var tasks = new List<Task<int>>();

			foreach (var request in requests)
			{
				tasks.Add(SendRequest(request));
			}

			await Task.WhenAll(tasks);

			foreach (var task in tasks)
			{
				responses.Add(task.Result);
			}
		}
	}
}