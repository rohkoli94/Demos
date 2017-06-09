using Finance;
using System;

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = args.Length > 1 ? Type.GetType(args[1]) : typeof(PersonalLoan);
		bool rb = t.IsDefined(typeof(ReducingBalanceAttribute), false);
		ILoanPolicy pol = (ILoanPolicy)Activator.CreateInstance(t);
		int m = 10;

		for(int n = 1; n <= m; ++n)
		{
			float r = pol.GetInterestRate(p, n);
			double emi;
			
			if(rb)
			{
				float i = r / 1200;
				emi = p * i / (1 - Math.Pow(1 + i, -12 * n));
			}
			else 
			{
				emi = p * Math.Pow(1 + r / 100, n) / (12 * n);
			}

			Console.WriteLine("{0}\t{1}\t{2:0.00}", n, rb, emi);
		}
	}
}