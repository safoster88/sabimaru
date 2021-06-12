namespace Sabimaru.Components
{
	using System;
	using System.Collections.Generic;

	public class ComponentManager
	{
		private readonly List<List<ValueType>> components = new();

		public void AddComponent(int entityId, ValueType component)
		{
			if (components.Count <= entityId)
			{
				components.Insert(entityId, new List<ValueType>());
			}
			
			components[entityId].Add(component);
		}

		public List<ValueType> GetComponents(int entityId) => components[entityId];
	}
}