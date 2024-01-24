namespace ProvaPub.Services
{
	public class RandomService
	{
		public RandomService()
		{
		}
		public int GetRandom()
		{
			return new Random(Guid.NewGuid().GetHashCode()).Next(100);
		}

	}
}
