namespace Sabimaru.Components
{
	using MediatR;
	using Sabimaru.Entities;

	public class AddComponentRequestHandler : RequestHandler<AddComponentRequest>
	{
		private readonly EntityFactory entityFactory;
		private readonly ComponentManager componentManager;

		public AddComponentRequestHandler(
			EntityFactory entityFactory,
			ComponentManager componentManager)
		{
			this.entityFactory = entityFactory;
			this.componentManager = componentManager;
		}

		protected override void Handle(AddComponentRequest request)
		{
			if (request.EntityId >= entityFactory.IdCounter)
			{
				throw new EntityDoesNotExistException();
			}
			
			componentManager.AddComponent(request.EntityId, request.Component);
		}
	}
}