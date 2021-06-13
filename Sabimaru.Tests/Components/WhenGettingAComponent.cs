namespace Sabimaru.Tests.Components
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using FluentAssertions;
	using FluentAssertions.Execution;
	using Sabimaru.Components.Get.Multiple;
	using Sabimaru.Components.Get.Single;
	using Xunit;

	public abstract class WhenGettingAComponent : TestBase
	{
		private readonly int entityId;
		private readonly TestComponent1 component1;
		private readonly TestComponent2 component2;

		protected WhenGettingAComponent()
		{
			entityId = CreateEntity();
			AddComponent(entityId, component1);
			AddComponent(entityId, component2);
		}

		public class UsingTheManyRequest : WhenGettingAComponent
		{
			private Task<List<ValueType>> SendRequest() =>
				SendRequest(new GetComponentsRequest
				{
					EntityId = entityId
				});

			[Fact]
			public async Task ThenAllComponentsShouldBeReturned()
			{
				var components = await SendRequest();

				using var _ = new AssertionScope();
				
				components.Should().Contain(component1);
				components.Should().Contain(component2);
			}
		}

		public class UsingTheSingleRequest : WhenGettingAComponent
		{
			private Task<ValueType> SendRequest() =>
				SendRequest(new GetComponentRequest
				{
					EntityId = entityId,
					Type = typeof(TestComponent1)
				});

			[Fact]
			public async Task ThenTheRequestedComponentShouldBeReturned()
			{
				var component = await SendRequest();

				component.Should().Be(component1);
			}
		}
	}
}