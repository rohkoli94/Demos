using System;

static class Program
{
	private static double Average(double first, double second)
	{
		return (first + second) / 2;
	}

	private static double Average(double first, double second, double third) => (first + second + third) / 3;

	private static double Average(double first, double second, params double[] remaining)
	{
		double total = first + second;

		foreach(double value in remaining)
			total += value;

		return total / (remaining.Length + 2);
	}

	public static void Main()
	{
		Console.WriteLine("Average of two values = {0}", Average(19.8, 24.9));		
		Console.WriteLine("Average of three values = {0}", Average(19.8, 24.9, 17.4));
		Console.WriteLine("Average of five values = {0}", Average(19.8, 24.9, 17.4, 28.7, 15.6)); //Average(19.8, 24.9, new double[]{17.4, 28.7, 15.6})		
	}
}