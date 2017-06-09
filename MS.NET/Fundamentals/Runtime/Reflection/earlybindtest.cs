using Finance;
using System;

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = args.Length > 1 ? Type.GetType(args[1]) : typeof(PersonalLoan);
		ILoanPolicy pol = (ILoanPolicy)Activator.CreateInstance(t);
		int m = 10;

		for(int n = 1; n <= m; ++n)
		{
			float r = pol.GetInterestRate(p, n);
			double emi;
			
			emi = p * Math.Pow(1 + r / 100, n) / (12 * n);

			Console.WriteLine("{0}\t{1:0.00}", n, emi);
		}
	}
}