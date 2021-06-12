namespace Sabimaru.Tests
{
	using System;
	using MediatR;
	using Microsoft.Extensions.DependencyInjection;
	using Sabimaru.Binding;

	public class TestBootstrapper
	{
		public TestBootstrapper()
		{
			var services = new ServiceCollection();
			services.AddSabimaru();
			Services = services.BuildServiceProvider();
		}
		
		public IServiceProvider Services { get; }

		public IMediator Mediator => Services.GetRequiredService<IMediator>();
	}
}