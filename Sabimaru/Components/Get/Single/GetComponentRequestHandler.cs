namespace Sabimaru.Components.Get.Single
{
	using System;
	using MediatR;

	public class GetComponentRequestHandler : RequestHandler<GetComponentRequest, ValueType>
	{
		private readonly ComponentManager componentManager;

		public GetComponentRequestHandler(
			ComponentManager componentManager)
		{
			this.componentManager = componentManager;
		}

		protected override ValueType Handle(GetComponentRequest request) => componentManager.GetComponent(request.EntityId, request.Type);
	}
}