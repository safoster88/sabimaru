namespace Sabimaru.Tests.Systems
{
	using System.Threading.Tasks;
	using FluentAssertions;
	using FluentAssertions.Execution;
	using Sabimaru.Systems.Add;
	using Sabimaru.Tests.Components;
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

			ForceEngineTicks(5);

			system.TickCount.Should().Be(5);
		}

		[Fact]
		public async Task ThenTheSystemReceivesFixedTickCallbacks()
		{
			await SendRequest();

			ForceEngineFixedTicks(5);

			system.FixedTickCount.Should().Be(5);
		}

		[Fact]
		public async Task ThenTheSystemShouldBeInitialized()
		{
			await SendRequest();
			
			ForceEngineTicks(1);

			system.IsInitialized.Should().BeTrue();
		}

		[Fact]
		public async Task ThenTheSystemShouldReceiveTheEntitiesWithTheExpectedComponents()
		{
			await SendRequest();
			
			var e1 = CreateEntity();
			var e2 = CreateEntity();
			var e3 = CreateEntity();
			var e4 = CreateEntity();
			
			AddComponent(e1, new TestComponent1());
			AddComponent(e1, new TestComponent2());
			
			AddComponent(e2, new TestComponent1());
			AddComponent(e2, new TestComponent3());
			
			AddComponent(e3, new TestComponent1());
			AddComponent(e3, new TestComponent2());
			
			AddComponent(e4, new TestComponent2());
			AddComponent(e4, new TestComponent3());
			
			ForceEngineTicks(1);
			ForceEngineFixedTicks(1);

			using var _ = new AssertionScope();
			
			system.TickEntities.Should().Contain(e1);
			system.TickEntities.Should().Contain(e3);
			system.TickEntities.Should().NotContain(e2);
			system.TickEntities.Should().NotContain(e4);
			
			system.FixedTickEntities.Should().Contain(e1);
			system.FixedTickEntities.Should().Contain(e3);
			system.FixedTickEntities.Should().NotContain(e2);
			system.FixedTickEntities.Should().NotContain(e4);
		}
	}
}