namespace Sabimaru.Tests.Components
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using FluentAssertions;
	using FluentAssertions.Execution;
	using Sabimaru.Components;
	using Sabimaru.Components.Get.Multiple;
	using Sabimaru.Components.Get.Single;
	using Xunit;

	public abstract class WhenGettingAComponent : TestBase
	{
		public abstract class AndTheEntityExists : WhenGettingAComponent
		{
			private readonly int entityId;
			private readonly TestComponent1 component1 = new();
			private readonly TestComponent2 component2 = new();

			public AndTheEntityExists()
			{
				entityId = CreateEntity();
				AddComponent(entityId, component1);
				AddComponent(entityId, component2);
			}
			
			public class UsingTheManyRequest : AndTheEntityExists
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

			public class UsingTheSingleRequest : AndTheEntityExists
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

		public abstract class AndTheEntityDoesNotExist : WhenGettingAComponent
		{
			public class UsingTheManyRequest : AndTheEntityDoesNotExist
			{
				private Task<List<ValueType>> SendRequest() =>
					SendRequest(new GetComponentsRequest
					{
						EntityId = 0
					});

				[Fact]
				public async Task ThenTheResultShouldBeEmpty()
				{
					var components = await SendRequest();

					components.Should().BeEmpty();
				}
			}

			public class UsingTheSingleRequest : AndTheEntityDoesNotExist
			{
				private Task<ValueType> SendRequest() =>
					SendRequest(new GetComponentRequest
					{
						EntityId = 0,
						Type = typeof(TestComponent1)
					});

				[Fact]
				public async Task ThenNoComponentShouldBeReturned()
				{
					var component = await SendRequest();

					component.Should().Be(Component.None);
				}
			}
		}
	}
}