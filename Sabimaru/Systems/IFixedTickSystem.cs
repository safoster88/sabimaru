namespace Sabimaru.Systems
{
	using System.Collections.Generic;

	public interface IFixedTickSystem : ISystem
	{
		void FixedTick(List<int> entities, float dt);
	}
}