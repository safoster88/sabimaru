namespace Sabimaru.Components.Remove
{
	using MediatR;

	public class RemoveComponentRequestHandler : RequestHandler<RemoveComponentRequest>
	{
		private readonly ComponentManager componentManager;

		public RemoveComponentRequestHandler(
			ComponentManager componentManager)
		{
			this.componentManager = componentManager;
		}

		protected override void Handle(
			RemoveComponentRequest request)
		{
			componentManager.RemoveComponent(request.EntityId, request.ComponentType);
		}
	}
}