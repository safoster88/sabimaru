namespace Sabimaru.Entities
{
	public class EntityFactory
	{
		private int idCounter;
		
		public int Create() => idCounter++;
	}
}