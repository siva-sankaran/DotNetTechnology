<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
</Query>

void Main()
{
	Calculate();
}

// Define other methods and classes here
void Calculate()
{
	Stopwatch sw = new Stopwatch(); 
	sw.Start();
	Calculate1();
	Calculate2();
	Calculate3();
	sw.Stop();
	Console.WriteLine("Time Elapsed {0}", sw.Elapsed);
}
int Calculate1()
{
	Thread.Sleep(1000);
	Console.WriteLine("Calculating result1");
	return 100;
}

int Calculate2()
{
	Thread.Sleep(1000);
	Console.WriteLine("Calculating result2");
	return 200;
}

int Calculate3()
{
	Thread.Sleep(1000);
	Console.WriteLine("Calculating result2");
	return 300;
}