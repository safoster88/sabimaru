namespace Sabimaru.Tests.Engine
{
	using System;
	using Sabimaru.Engine;

	public class TestEngineBootstrapper : IEngineBootstrapper
	{
		public event EventHandler<float> Tick;
		
		public event EventHandler<float> FixedTick;

		public void InvokeTick(float dt = 1) => OnTick(dt);

		public void InvokeFixedTick(float dt = 1) => OnFixedTick(dt);

		protected virtual void OnTick(float e)
		{
			Tick?.Invoke(this, e);
		}

		protected virtual void OnFixedTick(float e)
		{
			FixedTick?.Invoke(this, e);
		}
	}
}