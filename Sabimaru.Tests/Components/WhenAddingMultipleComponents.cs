namespace Sabimaru.Tests.Components
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using FluentAssertions;
	using Sabimaru.Components.Add.Multiple;
	using Sabimaru.Entities;
	using Xunit;

	public abstract class WhenAddingMultipleComponents : TestBase
	{
		private readonly AddComponentsRequest request = new()
		{
			EntityId = 0,
			Components = new List<ValueType>
			{
				new TestComponent1(),
				new TestComponent2()
			}
		};

		public class AndTheEntityDoesNotExist : WhenAddingMultipleComponents
		{
			[Fact]
			public async Task ThenAnEntityDoesNotExistExceptionIsThrown()
			{
				await FluentActions.Awaiting(() => SendRequest(request)).Should().ThrowAsync<EntityDoesNotExistException>();
			}
		}

		public class AndTheEntityExists : WhenAddingMultipleComponents
		{
			public AndTheEntityExists()
			{
				SabiApi.CreateEntity();
			}

			[Fact]
			public async Task ThenAllTheComponentsShouldBeInTheComponentsList()
			{
				await SendRequest(request);
			}
		}
	}
}