using System;

static class Program
{
	//private static Nullable<double> Lookup(string name)
	private static double? Lookup(string name)
	{
		string[] names = {"jack", "jill", "john", "jane"};
		double[] balances = {9000, 13000, 15000, 8000};
		int i = Array.IndexOf(names, name);

		if(i >= 0)
			return balances[i];

		return null;
	}

	public static void Main(string[] args)
	{
		double? bal = Lookup(args[0]);

		if(bal == null)
			Console.WriteLine("No such name!");
		else
			Console.WriteLine("Balance = {0}", bal);

		Console.WriteLine("Annual interest = {0}", 0.04 * (bal ?? 0)); //(bal != null ? bal : 0)
	}
}