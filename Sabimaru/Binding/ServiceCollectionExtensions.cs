namespace Sabimaru.Binding
{
	using Microsoft.Extensions.DependencyInjection;
	using Sabimaru.Engine;

	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddSabimaru(
			this IServiceCollection services,
			IEngineBootstrapper engineBootstrapper)
		{
			var installer = new Installer();
			installer.Install(services);
			installer.BootstrapEngine(services, engineBootstrapper);
			return services;
		}
	}
}