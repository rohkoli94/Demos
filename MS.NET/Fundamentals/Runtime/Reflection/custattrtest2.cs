using Finance;
using System;
using System.Reflection;

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = Type.GetType(args[1]);
		MethodInfo mi = t.GetMethod(args[2], new Type[]{typeof(double), typeof(int)});
		MaxDurationAttribute md = (MaxDurationAttribute)Attribute.GetCustomAttribute(mi, typeof(MaxDurationAttribute));
		object pol = Activator.CreateInstance(t);
		int m = md != null ? md.Limit : 10;

		for(int n = 1; n <= m; ++n)
		{
			float r = (float)mi.Invoke(pol, new object[]{p, n});
			double emi;
			
			emi = p * Math.Pow(1 + r / 100, n) / (12 * n);

			Console.WriteLine("{0}\t{1:0.00}", n, emi);
		}
	}
}