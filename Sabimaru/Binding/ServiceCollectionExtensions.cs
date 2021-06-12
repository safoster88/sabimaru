namespace Sabimaru.Binding
{
	using Microsoft.Extensions.DependencyInjection;

	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddSabimaru(
			this IServiceCollection services)
		{
			var installer = new Installer();
			installer.Install(services);
			return services;
		}
	}
}