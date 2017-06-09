using System;

delegate bool Filter(int value);

static class Counter
{
	public static int CountIf(int[] values, Filter check)
	{
		int count = 0;

		foreach(int value in values)
		{
			if(check(value)) //implicit call to Invoke
				++count;
		}	

		return count;
	}
}

static class Program
{
	public static void Main()
	{
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};

		Console.Write("All squares:");
		foreach(int n in squares) Console.Write(" {0}", n);
		Console.WriteLine();
		
		//passing anonymous method
		Console.WriteLine("Number of odd squares = {0}", Counter.CountIf(squares, delegate(int n){ return (n % 2) == 1; }));
		
		int m = 50;
		//passing lamda expression
		Console.WriteLine("Number of big squares = {0}", Counter.CountIf(squares, n => n > m));
	}
}