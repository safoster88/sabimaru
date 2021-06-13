namespace Sabimaru.Systems
{
	using System.Collections.Generic;

	public interface ITickSystem : ISystem
	{
		void Tick(List<int> entities, float dt);
	}
}