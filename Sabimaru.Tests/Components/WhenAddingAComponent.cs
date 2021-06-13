namespace Sabimaru.Tests.Components
{
	using System.Threading.Tasks;
	using FluentAssertions;
	using Sabimaru.Components;
	using Sabimaru.Components.Add.Single;
	using Sabimaru.Components.Get;
	using Sabimaru.Components.Get.Multiple;
	using Sabimaru.Entities;
	using Xunit;

	public abstract class WhenAddingAComponent : TestBase
	{
		private readonly AddComponentRequest request = new()
		{
			Component = new TestComponent1(),
			EntityId = 0
		};

		public class AndTheEntityExists : WhenAddingAComponent
		{
			public AndTheEntityExists()
			{
				SabiApi.CreateEntity();
			}

			[Fact]
			public async Task ThenTheComponentIsInTheEntityComponentsList()
			{
				await SendRequest(request);

				var components = SabiApi.GetComponents(request.EntityId);
				components.Should().ContainSingle();
			}
		}

		public class AndTheEntityDoesNotExist : WhenAddingAComponent
		{
			[Fact]
			public async Task ThenAnEntityDoesNotExistExceptionShouldBeThrown()
			{
				await FluentActions.Awaiting(() => SendRequest(request)).Should().ThrowAsync<EntityDoesNotExistException>();
			}
		}
	}
}