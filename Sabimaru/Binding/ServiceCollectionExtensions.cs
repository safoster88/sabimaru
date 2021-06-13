namespace Sabimaru.Binding
{
	using System;
	using Microsoft.Extensions.DependencyInjection;
	using Sabimaru.Engine;

	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddSabimaru(
			this IServiceCollection services,
			IEngineBootstrapper engineBootstrapper)
		{
			Installer.Install(services);
			Installer.BootstrapEngine(services, engineBootstrapper);
			return services;
		}

		public static IServiceProvider InitSabimaru(
			this IServiceProvider serviceProvider) =>
			Installer.Initialize(serviceProvider);
	}
}