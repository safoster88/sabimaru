namespace Sabimaru.Tests
{
	using System.Threading.Tasks;
	using MediatR;

	public abstract class TestBase
	{
		protected TestBootstrapper Bootstrapper { get; } = new();

		protected IMediator Mediator => Bootstrapper.Mediator;

		protected Task SendRequest(IRequest request) => Mediator.Send(request);

		protected Task<TResponse> SendRequest<TResponse>(IRequest<TResponse> request) => Mediator.Send(request);

		protected Task PublishNotification(INotification notification) => Mediator.Publish(notification);
	}
}