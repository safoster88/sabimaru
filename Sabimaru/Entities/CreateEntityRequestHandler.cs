namespace Sabimaru.Entities
{
	using MediatR;

	public class CreateEntityRequestHandler : RequestHandler<CreateEntityRequest, Entity>
	{
		private readonly EntityFactory entityFactory;

		public CreateEntityRequestHandler(
			EntityFactory entityFactory)
		{
			this.entityFactory = entityFactory;
		}

		protected override Entity Handle(
			CreateEntityRequest request)
		{
			return entityFactory.Create();
		}
	}
}