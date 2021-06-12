namespace Sabimaru.Entities
{
	using MediatR;

	public class CreateEntityRequestHandler : RequestHandler<CreateEntityRequest, int>
	{
		private readonly EntityFactory entityFactory;

		public CreateEntityRequestHandler(
			EntityFactory entityFactory)
		{
			this.entityFactory = entityFactory;
		}

		protected override int Handle(
			CreateEntityRequest request)
		{
			return entityFactory.Create();
		}
	}
}