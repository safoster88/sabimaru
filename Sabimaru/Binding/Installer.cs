namespace Sabimaru.Binding
{
	using MediatR;
	using Microsoft.Extensions.DependencyInjection;
	using Sabimaru.Entities;

	public class Installer
	{
		public IServiceCollection Install(IServiceCollection services)
		{
			services.AddMediatR(typeof(Installer));
			services.AddSingleton<EntityFactory>();
			return services;
		}
	}
}