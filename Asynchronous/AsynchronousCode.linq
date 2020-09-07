<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Calculate(); //Now this Method will be fired and forgotten 
	//await Calculate();  //main() will be blocked here until the method finishes
	
	//if Main() has a method which dont depend on completion of Calculate() 
	//say AnotherCalculate() and third method(PrintResults()) which depends on completion above
	//two methods, we could do as follow
	
	//Task t = Calculate();
	//AnotherCalculate();
	//await t;
	//PrintResults();
	
	//We need to modify Main() with keyword async as we use await inside it
	
}

// Define other methods and classes here
async Task Calculate()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	
	var tks = new List<Task>();
	tks.Add(Calculate1());
	tks.Add(Calculate2());
	tks.Add(Calculate3());
	await Task.WhenAll(tks);
	
	sw.Stop();
	Console.WriteLine("Time Elapsed {0}", sw.Elapsed);
}
async Task<int> Calculate1()
{
	await Task.Delay(1000);
	Console.WriteLine("Calculating result1");
	return 100;
}

async Task<int>  Calculate2()
{
    await Task.Delay(1000); //.GetAwaiter().GetResult();
	Console.WriteLine("Calculating result2");
	return 200;
}

async Task<int>  Calculate3()
{
    await Task.Delay(1000); //.GetAwaiter().GetResult();
	Console.WriteLine("Calculating result3");
	return 300;
}