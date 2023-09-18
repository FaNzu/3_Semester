namespace Budweg
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//MenuClass menu = new MenuClass();
			//menu.Menu();
			List<string> cities =  new();
			cities.Add("New York");
			cities.Add("London");
			cities.Add("Mumbai");
			cities.Add("Chicago");
			Console.WriteLine(cities);
			Console.WriteLine(cities[2]);

		}
	}
}