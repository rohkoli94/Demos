using System;
using System.Runtime.InteropServices;

static class Program
{
	[StructLayout(LayoutKind.Sequential)]
	struct FixedDeposit
	{
		public int Id;
		public double Amount;
		public int Period;	
	}
	
	[DllImport(@"legacy\x86\invest", CallingConvention=CallingConvention.Cdecl)]
	private extern static int InitFixedDeposit(double amount, int period, out FixedDeposit fd);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	delegate float Scheme(int period);

	[DllImport(@"legacy\x86\invest", CallingConvention=CallingConvention.Cdecl)]
	private extern static double GetMaturityValue(ref FixedDeposit fd, Scheme policy);
	
	public static void Main()
	{
		Console.Write("Amount: ");
		double amount = double.Parse(Console.ReadLine());
		Console.Write("Period: ");
		int period = int.Parse(Console.ReadLine());

		FixedDeposit fd;
		InitFixedDeposit(amount, period, out fd);
		Console.WriteLine("New fixed-deposit ID: {0}", fd.Id);
		double mv = GetMaturityValue(ref fd, n => n < 3 ? 8 : 9);
		Console.WriteLine("Maturity value: {0:0.00}", mv);			
	}
}