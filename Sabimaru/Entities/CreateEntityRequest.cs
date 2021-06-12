namespace Sabimaru.Entities
{
	using MediatR;

	public record CreateEntityRequest : IRequest<Entity>
	{
	}
}