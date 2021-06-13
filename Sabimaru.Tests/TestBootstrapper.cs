namespace Sabimaru.Tests
{
	using System;
	using MediatR;
	using Microsoft.Extensions.DependencyInjection;
	using Sabimaru.Binding;
	using Sabimaru.Tests.Engine;

	public class TestBootstrapper
	{
		public TestBootstrapper()
		{
			var services = new ServiceCollection();
			services.AddSabimaru(Engine);
			Services = services.BuildServiceProvider();
		}
		
		public IServiceProvider Services { get; }

		public IMediator Mediator => Services.GetRequiredService<IMediator>();

		public TestEngineBootstrapper Engine { get; } = new();
	}
}