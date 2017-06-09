using System;

static class Program
{
	public static void Main()
	{
		Console.Write("Weight  : ");
		double wgt = double.Parse(Console.ReadLine());
		Console.Write("Distance: ");
		int dst = int.Parse(Console.ReadLine());

		Type t = Type.GetTypeFromProgID("METLogistics.AirCargo");
		dynamic cargo = Activator.CreateInstance(t);
		
		Console.WriteLine("Total tariff: {0:0.00}", cargo.QuoteTariff(wgt, dst));
		Console.WriteLine("Total time  : {0:0.00}", cargo.EstimateTime(dst));
	}
}