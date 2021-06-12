namespace Sabimaru.Tests.Entities
{
	using System.Threading.Tasks;
	using FluentAssertions;
	using Sabimaru.Entities;
	using Xunit;

	public class WhenReceivingACreateEntityRequest : TestBase
	{
		private readonly CreateEntityRequest request = new();

		[Fact]
		public async Task ThenTheEntityShouldHaveIdZero()
		{
			var entity = await SendRequest(request);

			entity.Should().Be(0);
		}
	}
}