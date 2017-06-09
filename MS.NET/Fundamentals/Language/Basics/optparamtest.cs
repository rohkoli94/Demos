using System;

static class Program
{
	private static double GetIncome(double invest, int duration=3, string risk="medium")
	{
		double rate = 0;
		
		switch(risk)
		{
			case "low":
				rate = 7.5;
				break;
			case "high":
				rate = 10.5;
				break;
			default:
				rate = 8.5;
				break;
		}	
		
		double amount = invest * Math.Pow(1 + rate / 100, duration);

		return amount - invest;
	}

	public static void Main(string[] args)
	{
		try
		{
			double inv = Convert.ToDouble(args[0]);
			
			Console.WriteLine("Income in GOLD scheme: {0:0.00}", GetIncome(inv, 4, "high"));
			Console.WriteLine("Income in SILVER scheme: {0:0.00}", GetIncome(inv));
			Console.WriteLine("Income in BRONZE scheme: {0:0.00}", GetIncome(inv, risk:"low"));
		}
		catch(IndexOutOfRangeException)
		{
			Console.WriteLine("Input is missing!");
		}
		catch
		{
			Console.WriteLine("Input is invalid!");
		}
	}
}