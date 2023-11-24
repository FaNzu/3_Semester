using Spectre.Console;
calc calc = new calc();


uint number = 2; //starting number
int count = 0;
var watch = new System.Diagnostics.Stopwatch();
watch.Start();//start timer
do
{
	bool answer = calc.Isprime(number);
	if (answer)
	{
		count++;
		AnsiConsole.MarkupLine($"[green]is {number} a prime: {answer}[/]");
	}
	number++;
}while(number != 1000);
watch.Stop();//turn off timer
AnsiConsole.MarkupLine($"[blue]number of prime numbers in the interval: {count}[/]");
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms for loop"); //print timer

watch.Restart();

AnsiConsole.MarkupLine($"[green]is 4294967291 a prime: {calc.Isprime(4294967291)}[/]"); //calculate the largest 32 bit prime number
watch.Stop();//turn off timer

Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms"); //print timer


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
}