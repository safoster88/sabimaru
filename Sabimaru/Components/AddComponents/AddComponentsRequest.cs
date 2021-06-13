namespace Sabimaru.Components.AddComponents
{
	using System;
	using System.Collections.Generic;
	using MediatR;

	public record AddComponentsRequest : IRequest
	{
		public int EntityId { get; init; }
		
		public List<ValueType> Components { get; init; }
	}
}