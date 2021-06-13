namespace Sabimaru.Tests.Components
{
	using System.Threading.Tasks;
	using FluentAssertions;
	using Sabimaru.Components;
	using Sabimaru.Components.Get.Multiple;
	using Sabimaru.Components.Remove;
	using Sabimaru.Entities;
	using Xunit;

	public abstract class WhenRemovingAComponent : TestBase
	{
		private readonly RemoveComponentRequest request = new()
		{
			EntityId = 0,
			ComponentType = typeof(TestComponent1)
		};

		public class AndTheEntityDoesNotExist : WhenRemovingAComponent
		{
			[Fact]
			public async Task ThenAnEntityDoesNotExistExceptionIsThrown()
			{
				await FluentActions.Awaiting(() => SendRequest(request)).Should().ThrowAsync<EntityDoesNotExistException>();
			}
		}

		public abstract class AndTheEntityExists : WhenRemovingAComponent
		{
			protected AndTheEntityExists()
			{
				SabiApi.CreateEntity();
			}

			public class AndTheComponentIsAttached : AndTheEntityExists
			{
				public AndTheComponentIsAttached()
				{
					SabiApi.AddComponent(0, new TestComponent1());
				}
				
				[Fact]
				public async Task ThenTheComponentIsNoLongerPresentInTheComponentsList()
				{
					await SendRequest(request);

					var components = await Mediator.Send(new GetComponentsRequest
					{
						EntityId = 0
					});

					components.Should().NotContain(c => c.GetType() == request.ComponentType);
				}	
			}

			public class AndTheComponentIsNotAttached : AndTheEntityExists
			{
				[Fact]
				public async Task ThenAComponentNotAttachedExceptionIsThrown()
				{
					await FluentActions.Awaiting(() => SendRequest(request)).Should()
						.ThrowAsync<ComponentNotAttachedException>();
				}
			}
		}
	}
}