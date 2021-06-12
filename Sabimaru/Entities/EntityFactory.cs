namespace Sabimaru.Entities
{
	public class EntityFactory
	{
		private int idCounter;
		
		public Entity Create() => new Entity(idCounter++);
	}
}