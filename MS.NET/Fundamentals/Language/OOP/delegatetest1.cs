using System;

delegate bool Filter(int value);

static class Counter
{
	public static int CountIf(int[] values, Filter check)
	{
		int count = 0;

		foreach(int value in values)
		{
			if(check.Invoke(value))
				++count;
		}	

		return count;
	}
}

static class Program
{
	private static bool IsOdd(int value)
	{
		return (value % 2) == 1;
	}

	//nested class - can only refer to static members of outer class
	class IsBiggerThan
	{
		private int limit;

		internal IsBiggerThan(int l)
		{
			limit = l;
		}

		public bool Confirm(int value)
		{
			return value > limit;
		}
	}

	public static void Main()
	{
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};

		Console.Write("All squares:");
		foreach(int n in squares) Console.Write(" {0}", n);
		Console.WriteLine();
		
		Console.WriteLine("Number of odd squares = {0}", Counter.CountIf(squares, IsOdd));
		Console.WriteLine("Number of big squares = {0}", Counter.CountIf(squares, new IsBiggerThan(50).Confirm));
	}
}