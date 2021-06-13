namespace Sabimaru
{
	using System;
	using System.Collections.Generic;
	using MediatR;
	using Sabimaru.Components.Add.Multiple;
	using Sabimaru.Components.Add.Single;
	using Sabimaru.Components.Get.Multiple;
	using Sabimaru.Components.Get.Single;
	using Sabimaru.Components.Remove;
	using Sabimaru.Entities;
	using Sabimaru.Systems;
	using Sabimaru.Systems.Add;

	public class SabiApi
	{
		private readonly IMediator mediator;

		public SabiApi(IMediator mediator)
		{
			this.mediator = mediator;
		}

		public int CreateEntity() =>
			mediator.Send(new CreateEntityRequest()).Result;

		public List<ValueType> GetComponents(int entityId) => 
			mediator.Send(new GetComponentsRequest { EntityId = entityId }).Result;

		public ValueType GetComponent(int entityId, Type componentType) =>
			mediator.Send(new GetComponentRequest { EntityId = entityId, Type = componentType }).Result;

		public TComponent GetComponent<TComponent>(int entityId) where TComponent : struct =>
			(TComponent)GetComponent(entityId, typeof(TComponent));

		public void AddComponent<TComponent>(int entityId, TComponent component) where TComponent : struct =>
			mediator.Send(new AddComponentRequest { EntityId = entityId, Component = component });

		public void AddComponents(int entityId, List<ValueType> components) =>
			mediator.Send(new AddComponentsRequest { EntityId = entityId, Components = components });

		public void RemoveComponent(int entityId, Type componentType) =>
			mediator.Send(new RemoveComponentRequest { EntityId = entityId, ComponentType = componentType });

		public void RemoveComponent<TComponent>(int entityId) =>
			mediator.Send(new RemoveComponentRequest { EntityId = entityId, ComponentType = typeof(TComponent) });

		public void AddSystem(ISystem system) =>
			mediator.Send(new AddSystemRequest { System = system });
	}
}