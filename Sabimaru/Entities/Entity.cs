namespace Sabimaru.Entities
{
	public sealed class Entity
	{
		public Entity(
			int id)
		{
			Id = id;
		}
		
		public int Id { get; }
	}
}