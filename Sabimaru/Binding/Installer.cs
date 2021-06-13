namespace Sabimaru.Binding
{
	using MediatR;
	using Microsoft.Extensions.DependencyInjection;
	using Sabimaru.Components;
	using Sabimaru.Engine;
	using Sabimaru.Entities;
	using Sabimaru.Systems;

	public class Installer
	{
		public IServiceCollection Install(IServiceCollection services)
		{
			services.AddMediatR(typeof(Installer));
			services.AddSingleton<EntityFactory>();
			services.AddSingleton<ComponentManager>();
			services.AddSingleton<SystemManager>();
			return services;
		}

		public IServiceCollection BootstrapEngine(
			IServiceCollection services,
			IEngineBootstrapper engineMount)
		{
			return services.AddSingleton(engineMount);
		}
	}
}