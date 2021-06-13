namespace Sabimaru.Engine
{
	using System;

	public interface IEngineBootstrapper
	{
		event EventHandler<float> Tick;

		event EventHandler<float> FixedTick;
	}
}