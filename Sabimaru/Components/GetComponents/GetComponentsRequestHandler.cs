namespace Sabimaru.Components.GetComponents
{
	using System;
	using System.Collections.Generic;
	using MediatR;

	public class GetComponentsRequestHandler : RequestHandler<GetComponentsRequest, List<ValueType>>
	{
		private readonly ComponentManager componentManager;

		public GetComponentsRequestHandler(
			ComponentManager componentManager)
		{
			this.componentManager = componentManager;
		}

		protected override List<ValueType> Handle(GetComponentsRequest request)
		{
			return componentManager.GetComponents(request.EntityId);
		}
	}
}