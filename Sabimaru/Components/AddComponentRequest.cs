namespace Sabimaru.Components
{
	using System;
	using MediatR;

	public record AddComponentRequest : IRequest
	{
		public int EntityId { get; init; }
		
		public ValueType Component { get; init; }
	}
}