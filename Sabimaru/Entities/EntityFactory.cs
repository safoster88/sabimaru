namespace Sabimaru.Entities
{
	public class EntityFactory
	{
		public int IdCounter { get; private set; }
		
		public int Create() => IdCounter++;
	}
}