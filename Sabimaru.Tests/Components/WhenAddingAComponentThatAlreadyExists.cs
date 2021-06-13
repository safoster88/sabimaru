namespace Sabimaru.Tests.Components
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using FluentAssertions;
	using Sabimaru.Components;
	using Sabimaru.Components.Add.Multiple;
	using Sabimaru.Components.Add.Single;
	using Xunit;

	public abstract class WhenAddingAComponentThatAlreadyExists : TestBase
	{
		private readonly int entityId;
		
		protected WhenAddingAComponentThatAlreadyExists()
		{
			entityId = SabiApi.CreateEntity();
			SabiApi.AddComponent(entityId, new TestComponent1());
		}

		protected abstract Task SendRequest();
		
		public class UsingTheSingleAdd : WhenAddingAComponentThatAlreadyExists
		{
			protected override Task SendRequest() =>
				SendRequest(new AddComponentRequest
				{
					EntityId = entityId,
					Component = new TestComponent1()
				});
		}

		public class WhenUsingTheMultiAdd : WhenAddingAComponentThatAlreadyExists
		{
			protected override Task SendRequest()
			{
				return SendRequest(new AddComponentsRequest
				{
					EntityId = entityId,
					Components = new List<ValueType>
					{
						new TestComponent1(),
						new TestComponent2()
					}
				});
			}
		}

		[Fact]
		public async Task ThenAComponentTypeAlreadyAttachedExceptionIsThrown()
		{
			await FluentActions.Awaiting(SendRequest).Should()
				.ThrowAsync<ComponentTypeAlreadyAttachedException>();
		}
	}
}