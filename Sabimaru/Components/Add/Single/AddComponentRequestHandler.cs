namespace Sabimaru.Components.Add.Single
{
	using MediatR;

	public class AddComponentRequestHandler : RequestHandler<AddComponentRequest>
	{
		private readonly ComponentManager componentManager;

		public AddComponentRequestHandler(
			ComponentManager componentManager)
		{
			this.componentManager = componentManager;
		}

		protected override void Handle(AddComponentRequest request)
		{
			componentManager.AddComponent(request.EntityId, request.Component);
		}
	}
}