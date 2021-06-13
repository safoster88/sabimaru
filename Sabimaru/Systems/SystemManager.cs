namespace Sabimaru.Systems
{
	using System.Collections.Generic;
	using Sabimaru.Components;
	using Sabimaru.Engine;

	public class SystemManager
	{
		private readonly ComponentManager componentManager;
		private readonly List<IInitSystem> pendingInitSystems = new();
		private readonly List<ITickSystem> tickSystems = new();
		private readonly List<IFixedTickSystem> fixedTickSystems = new();
		
		public SystemManager(
			IEngineBootstrapper engineBootstrapper,
			ComponentManager componentManager)
		{
			this.componentManager = componentManager;
			engineBootstrapper.Tick += OnTick;
			engineBootstrapper.FixedTick += OnFixedTick;
		}

		private void OnFixedTick(
			object sender,
			float dt)
		{
			foreach (var system in fixedTickSystems)
			{
				var entities = componentManager.GetEntitiesWithComponents(system.ComponentTypes);
				system.FixedTick(entities, dt);
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
				var entities = componentManager.GetEntitiesWithComponents(system.ComponentTypes);
				system.Tick(entities, dt);
			}
		}

		public void AddSystem(ISystem system)
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