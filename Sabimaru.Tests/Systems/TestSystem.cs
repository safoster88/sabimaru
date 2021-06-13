namespace Sabimaru.Tests.Systems
{
	using Sabimaru.Systems;

	public class TestSystem : ITickSystem, IFixedTickSystem, IInitSystem
	{
		public int TickCount { get; private set; }
		
		public int FixedTickCount { get; private set; }
		
		public bool IsInitialized { get; private set; }
		
		public void Tick(float dt) => TickCount++;

		public void FixedTick(float dt) => FixedTickCount++;

		public void Init() => IsInitialized = true;
	}
}