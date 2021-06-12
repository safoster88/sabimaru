namespace Sabimaru.Tests.Components
{
	using System.Threading.Tasks;
	using FluentAssertions;
	using Sabimaru.Components;
	using Sabimaru.Entities;
	using Xunit;

	public abstract class WhenAddingAComponent : TestBase
	{
		private readonly AddComponentRequest request = new()
		{
			Component = new TestComponent(),
			EntityId = 0
		};

		public class AndTheEntityExists : WhenAddingAComponent
		{
			public AndTheEntityExists()
			{
				SendRequest(new CreateEntityRequest()).Wait();
			}

			[Fact]
			public async Task ThenTheComponentIsInTheEntityComponentsList()
			{
				await SendRequest(request);

				var components = await SendRequest(new GetComponentsRequest
				{
					EntityId = request.EntityId
				});
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