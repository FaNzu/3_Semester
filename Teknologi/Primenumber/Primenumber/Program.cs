using Spectre.Console;
calc calc = new calc();


//uint number = 2; //starting number
//int count = 0;
//do
//{
//	bool answer = calc.Isprime(number);
//	if (answer)
//	{
//		count++;
//		AnsiConsole.MarkupLine($"[green]is {number} a prime: {answer}[/]");
//	}
//	number++;
//}while(number != 1000);
//AnsiConsole.MarkupLine($"[blue]number of prime numbers in the interval: {count}[/]");
List<uint> list = new List<uint>();
list = calc.GetFactors(32); 
foreach (uint item in list)
{
	Console.WriteLine(item);
}
//AnsiConsole.MarkupLine($"[green]is 4294967291 a prime: {calc.Isprime(4294967291)}[/]"); //calculate the largest 32 bit prime number


class calc
{
	public bool Isprime(uint number)
	{
		string temp = number.ToString();
		double sqrn = Math.Sqrt(number);
		if (number == 2 ||number ==5) //odd prime numbers that isnt easy to catch
		{
			return true;
		}
		if (number % 2 == 0 || temp.EndsWith("0")) // is even eller 0
		{
			return false;
		}
		if (temp.EndsWith("5")) //remove all numbers that ends with 5
		{
			return false;
		}
		for (int i = 3; i <= sqrn; i += 2) //burde lave do while ifølge allan love
		{
			if(number % i==0) //hvis tallet har en remainder/modulo på 0 aka kan divideres
			{
				return false;
			}
		}
		return true;
	}

	public List<uint> GetFactors(uint n)
	{
		HashSet<uint> f = new HashSet<uint>();
		HashSet<uint> g = new HashSet<uint>();

		for (uint i = 1; i <= 2 + (uint)Math.Sqrt(n); i++)
		{
			if (n % i == 0 && Isprime(i))
			{
				f.Add(i);
			}
		}

		foreach (uint j in f)
		{
			if (n % j == 0 && Isprime(n / j))
			{
				g.Add(n / j);
			}
		}

		if (Isprime(n))
		{
			f.Add(n);
		}

		f.UnionWith(g);

		List<uint> sortedFactors = new List<uint>(f);
		sortedFactors.Sort();

		return sortedFactors;
	}
	public int MySqrt(int x)
	{
			for (int i = 1;  i < x; i++)
			{
				if (i * i == x) return i;
				else if (i * i > x) return i-1;
			}
			return x;
	}
}