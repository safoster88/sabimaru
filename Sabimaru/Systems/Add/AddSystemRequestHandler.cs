namespace Sabimaru.Systems.Add
{
	using MediatR;

	public class AddSystemRequestHandler : RequestHandler<AddSystemRequest>
	{
		private readonly SystemManager systemManager;

		public AddSystemRequestHandler(
			SystemManager systemManager)
		{
			this.systemManager = systemManager;
		}

		protected override void Handle(AddSystemRequest request) => systemManager.AddSystem(request.System);
	}
}