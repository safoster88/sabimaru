namespace Sabimaru.Components.Remove
{
	using System;
	using MediatR;

	public record RemoveComponentRequest : IRequest
	{
		public int EntityId { get; init; }
		
		public Type ComponentType { get; init; }
	}
}