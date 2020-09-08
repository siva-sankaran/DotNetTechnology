<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Main() step 1".Dump();
	"Main() step 2".Dump();
	"Main() step 3".Dump();
	"Main() step 4".Dump();
	DoStuffAsync();
	"Main() step 5".Dump();
	"Main() step 6".Dump();
	"Main() step 7".Dump();
}

// Define other methods and classes here
//Only await keyword make an asynchronous execution. Mere async keyword method 
//decoration wont make asynchronous execution. Here Without await
//the DoStuffAsync() executes synchronously
async Task<int> DoStuffAsync()
{
	"DoStuffAsync() step 1".Dump();
	"DoStuffAsync() step 2".Dump();
	"DoStuffAsync() step 3".Dump();
	"DoStuffAsync() step 4".Dump();
	var result = 1; 
	//var result = await AsyncI_O_Operation_Simulation(); 
	//var result = await Task.FromResult(1);       //Even though await can make asynchronous 
												   //execution, if the asynchronous operation 
												   //represented by await's operand completes(d)
												   //while applying await
												   //then there is no asynchronous execution
	"DoStuffAsync() step 5".Dump();
	"DoStuffAsync() step 6".Dump();
	"DoStuffAsync() step 7".Dump();
	return result;
}

async Task<int> AsyncI_O_Operation_Simulation()
{
	await Task.Delay(1000);
	return 100;
}

//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await
//https://blog.stephencleary.com/2012/02/async-and-await.html