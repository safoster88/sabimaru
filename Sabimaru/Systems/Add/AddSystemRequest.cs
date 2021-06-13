namespace Sabimaru.Systems.Add
{
	using MediatR;

	public record AddSystemRequest : IRequest
	{
		public ISystem System { get; init; }
	}
}