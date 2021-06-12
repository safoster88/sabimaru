namespace Sabimaru.Binding
{
	using MediatR;
	using Microsoft.Extensions.DependencyInjection;
	using Sabimaru.Components;
	using Sabimaru.Entities;

	public class Installer
	{
		public IServiceCollection Install(IServiceCollection services)
		{
			services.AddMediatR(typeof(Installer));
			services.AddSingleton<EntityFactory>();
			services.AddSingleton<ComponentManager>();
			return services;
		}
	}
}