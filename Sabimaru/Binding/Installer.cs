namespace Sabimaru.Binding
{
	using System;
	using MediatR;
	using Microsoft.Extensions.DependencyInjection;
	using Sabimaru.Components;
	using Sabimaru.Engine;
	using Sabimaru.Entities;
	using Sabimaru.Systems;

	public static class Installer
	{
		public static IServiceCollection Install(IServiceCollection services)
		{
			services.AddMediatR(typeof(Installer));
			services.AddSingleton<EntityFactory>();
			services.AddSingleton<ComponentManager>();
			services.AddSingleton<SystemManager>();
			services.AddTransient<SabiApi>();
			return services;
		}

		public static IServiceCollection BootstrapEngine(
			IServiceCollection services,
			IEngineBootstrapper engineMount)
		{
			return services.AddSingleton(engineMount);
		}

		public static IServiceProvider Initialize(
			IServiceProvider services)
		{
			services.GetRequiredService<SystemManager>();
			return services;
		}
	}
}