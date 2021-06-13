namespace Sabimaru.Tests.Systems
{
	using System;
	using System.Collections.Generic;
	using Sabimaru.Systems;
	using Sabimaru.Tests.Components;

	public class TestSystem : ITickSystem, IFixedTickSystem, IInitSystem
	{
		public List<Type> ComponentTypes => new()
		{
			typeof(TestComponent1),
			typeof(TestComponent2)
		};
		
		public int TickCount { get; private set; }
		
		public int FixedTickCount { get; private set; }
		
		public bool IsInitialized { get; private set; }

		public List<int> TickEntities { get; } = new();

		public List<int> FixedTickEntities { get; } = new();
		
		public void Tick(List<int> entities, float dt)
		{
			TickEntities.Clear();
			TickEntities.AddRange(entities);
			TickCount++;
		}

		public void FixedTick(List<int> entities, float dt)
		{
			FixedTickEntities.Clear();
			FixedTickEntities.AddRange(entities);
			FixedTickCount++;
		}

		public void Init() => IsInitialized = true;
	}
}