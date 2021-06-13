namespace Sabimaru.Systems.Add
{
	using MediatR;

	public record AddSystemRequest : IRequest
	{
		public object System { get; init; }
	}
}