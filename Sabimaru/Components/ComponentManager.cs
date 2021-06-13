namespace Sabimaru.Components
{
	using System;
	using System.Collections.Generic;
	using Sabimaru.Entities;

	public class ComponentManager
	{
		private readonly EntityFactory entityFactory;
		private readonly List<List<ValueType>> components = new();
		
		public ComponentManager(
			EntityFactory entityFactory)
		{
			this.entityFactory = entityFactory;
		}

		public void AddComponent(int entityId, ValueType component)
		{
			GuardAgainstMissingEntity(entityId);
			
			if (components.Count <= entityId)
			{
				components.Insert(entityId, new List<ValueType>());
			}
			
			components[entityId].Add(component);
		}

		public void AddComponents(int entityId, List<ValueType> components)
		{
			foreach (var component in components)
			{
				AddComponent(entityId, component);
			}
		}

		public List<ValueType> GetComponents(int entityId) => components[entityId];

		private void GuardAgainstMissingEntity(int entityId)
		{
			if (entityId >= entityFactory.IdCounter)
			{
				throw new EntityDoesNotExistException();
			}
		}
	}
}