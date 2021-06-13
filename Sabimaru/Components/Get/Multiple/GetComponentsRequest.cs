namespace Sabimaru.Components.Get.Multiple
{
	using System;
	using System.Collections.Generic;
	using MediatR;

	public record GetComponentsRequest : IRequest<List<ValueType>>
	{
		public int EntityId { get; init; }
	}
}