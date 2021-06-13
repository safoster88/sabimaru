namespace Sabimaru.Components.AddComponents
{
	using MediatR;

	public class AddComponentsRequestHandler : RequestHandler<AddComponentsRequest>
	{
		private readonly ComponentManager componentManager;

		public AddComponentsRequestHandler(
			ComponentManager componentManager)
		{
			this.componentManager = componentManager;
		}

		protected override void Handle(AddComponentsRequest request)
		{
			componentManager.AddComponents(request.EntityId, request.Components);
		}
	}
}