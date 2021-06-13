namespace Sabimaru.Tests
{
	using System;
	using System.Threading.Tasks;
	using MediatR;
	using Sabimaru.Components.Add.Single;
	using Sabimaru.Entities;

	public abstract class TestBase
	{
		protected TestBootstrapper Bootstrapper { get; } = new();

		protected IMediator Mediator => Bootstrapper.Mediator;

		protected Task SendRequest(IRequest request) => Mediator.Send(request);

		protected Task<TResponse> SendRequest<TResponse>(IRequest<TResponse> request) => Mediator.Send(request);

		protected Task PublishNotification(INotification notification) => Mediator.Publish(notification);

		protected int CreateEntity() => SendRequest(new CreateEntityRequest()).Result;

		protected void AddComponent(int entityId, ValueType component) => SendRequest(new AddComponentRequest
		{
			Component = component,
			EntityId = entityId
		}).Wait();

		protected void ForceEngineTicks(int ticks)
		{
			for (var t = 0; t < ticks; t++)
			{
				Bootstrapper.Engine.InvokeTick();
			}
		}

		protected void ForceEngineFixedTicks(int fixedTicks)
		{
			for (var t = 0; t < fixedTicks; t++)
			{
				Bootstrapper.Engine.InvokeFixedTick();
			}
		}
	}
}