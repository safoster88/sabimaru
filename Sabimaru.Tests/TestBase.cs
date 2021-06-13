namespace Sabimaru.Tests
{
	using System.Threading.Tasks;
	using MediatR;

	public abstract class TestBase
	{
		protected TestBootstrapper Bootstrapper { get; } = new();

		protected IMediator Mediator => Bootstrapper.Mediator;

		protected SabiApi SabiApi => Bootstrapper.SabiApi;

		protected Task SendRequest(IRequest request) => Mediator.Send(request);

		protected Task<TResponse> SendRequest<TResponse>(IRequest<TResponse> request) => Mediator.Send(request);

		protected Task PublishNotification(INotification notification) => Mediator.Publish(notification);

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