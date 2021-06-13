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

		public ValueType GetComponent(
			int entityId,
			Type componentType)
		{
			if (!EntityExists(entityId))
			{
				return Component.None;
			}
			
			var components = GetComponents(entityId);
			return components.SingleOrDefault(c => c.GetType() == componentType);
		}

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

		private bool EntityExists(int entityId) => entityId < entityFactory.IdCounter;

		private void GuardAgainstMissingEntity(
			int entityId)
		{
			if (!EntityExists(entityId))
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

		private void GuardAgainstMissingComponentType(
			int entityId,
			Type componentType)
		{
			var componentList = GetOrCreateComponentList(entityId);
			if (componentList.All(x => x.GetType() != componentType))
			{
				throw new ComponentNotAttachedException();
			}
		}

		public void RemoveComponent(
			int entityId,
			Type componentType)
		{
			GuardAgainstMissingEntity(entityId);
			GuardAgainstMissingComponentType(entityId, componentType);
			var components = GetOrCreateComponentList(entityId);
			components.RemoveAll(c => c.GetType() == componentType);
		}
	}
}