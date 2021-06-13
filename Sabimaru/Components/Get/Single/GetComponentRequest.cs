namespace Sabimaru.Components.Get.Single
{
	using System;
	using MediatR;

	public record GetComponentRequest : IRequest<ValueType>
	{
		public int EntityId { get; init; }
		
		public Type Type { get; init; }
	}
}