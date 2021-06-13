namespace Sabimaru.Tests.Systems
{
	using System.Threading.Tasks;
	using FluentAssertions;
	using Sabimaru.Systems.Add;
	using Xunit;

	public class WhenAddingASystem : TestBase
	{
		private readonly TestSystem system = new();

		private Task SendRequest() => SendRequest(new AddSystemRequest
		{
			System = system
		});

		[Fact]
		public async Task ThenTheSystemReceivesTickCallbacks()
		{
			await SendRequest();

			WaitForEngineTicks(5);

			system.TickCount.Should().Be(5);
		}

		[Fact]
		public async Task ThenTheSystemReceivesFixedTickCallbacks()
		{
			await SendRequest();

			WaitForEngineFixedTicks(5);

			system.FixedTickCount.Should().Be(5);
		}

		[Fact]
		public async Task ThenTheSystemShouldBeInitialized()
		{
			await SendRequest();
			
			WaitForEngineTicks(1);

			system.IsInitialized.Should().BeTrue();
		}
	}
}