namespace Sabimaru.Systems
{
	using System.Collections.Generic;
	using Sabimaru.Engine;

	public class SystemManager
	{
		private readonly IEngineBootstrapper engineBootstrapper;
		private List<IInitSystem> pendingInitSystems = new();
		private List<ITickSystem> tickSystems = new();
		private List<IFixedTickSystem> fixedTickSystems = new();
		
		public SystemManager(
			IEngineBootstrapper engineBootstrapper)
		{
			this.engineBootstrapper = engineBootstrapper;
			engineBootstrapper.Tick += OnTick;
			engineBootstrapper.FixedTick += OnFixedTick;
		}

		private void OnFixedTick(
			object sender,
			float dt)
		{
			foreach (var system in fixedTickSystems)
			{
				system.FixedTick(dt);
			}
		}

		private void OnTick(
			object sender,
			float dt)
		{
			foreach (var pendingInitSystem in pendingInitSystems)
			{
				pendingInitSystem.Init();
			}
			pendingInitSystems.Clear();
			
			foreach (var system in tickSystems)
			{
				system.Tick(dt);
			}
		}

		public void AddSystem(object system)
		{
			if (system is IInitSystem initSystem)
			{
				pendingInitSystems.Add(initSystem);
			}

			if (system is ITickSystem tickSystem)
			{
				tickSystems.Add(tickSystem);
			}

			if (system is IFixedTickSystem fixedTickSystem)
			{
				fixedTickSystems.Add(fixedTickSystem);
			}
		}
	}
}