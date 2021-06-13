namespace Sabimaru.Components
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Sabimaru.Entities;

	public class ComponentManager
	{
		private readonly EntityFactory entityFactory;
		private readonly List<List<ValueType>> entityComponents = new();
		
		public ComponentManager(
			EntityFactory entityFactory)
		{
			this.entityFactory = entityFactory;
		}

		public void AddComponent(
			int entityId,
			ValueType componentToAdd) =>
			AddComponentsInternal(entityId, new List<ValueType> { componentToAdd });

		public void AddComponents(
			int entityId,
			List<ValueType> componentsToAdd) =>
			AddComponentsInternal(entityId, componentsToAdd);

		public List<ValueType> GetComponents(int entityId) => GetOrCreateComponentList(entityId);

		private void AddComponentsInternal(
			int entityId,
			List<ValueType> componentsToAdd)
		{
			GuardAgainstMissingEntity(entityId);
			GuardAgainstAlreadyAttachedComponentTypes(entityId, componentsToAdd);
			var attachedComponents = GetOrCreateComponentList(entityId);
			foreach (var componentToAdd in componentsToAdd)
			{
				attachedComponents.Add(componentToAdd);
			}
		}

		private List<ValueType> GetOrCreateComponentList(int entityId)
		{
			if (entityComponents.Count <= entityId)
			{
				entityComponents.Insert(entityId, new List<ValueType>());
			}

			return entityComponents[entityId];
		}

		private void GuardAgainstMissingEntity(
			int entityId)
		{
			if (entityId >= entityFactory.IdCounter)
			{
				throw new EntityDoesNotExistException();
			}
		}

		private void GuardAgainstAlreadyAttachedComponentTypes(
			int entityId,
			List<ValueType> newComponents)
		{
			var newComponentTypes = newComponents.Select(c => c.GetType());
			
			var components = GetComponents(entityId);
			if (components.Any(c => newComponentTypes.Contains(c.GetType())))
			{
				throw new ComponentTypeAlreadyAttachedException();
			}
		}
	}
}