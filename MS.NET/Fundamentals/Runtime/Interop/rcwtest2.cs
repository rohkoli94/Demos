using FinanceLib;
using System;
using System.Runtime.InteropServices;

[ComImport]
[Guid("1A87402F-A9F3-449F-ACB3-714A9275BEE0")]
class ReducingBalanceLoanClass {}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Console.Write("Amount: ");
		double amount = double.Parse(Console.ReadLine());	
		Console.Write("Period: ");
		short period = short.Parse(Console.ReadLine());	

		ILoan loan = (ILoan) new ReducingBalanceLoanClass();
		
		try
		{
			loan.Acquire(amount, period);
			Console.WriteLine("E.M.I: {0:0.00}", loan.GetInstallmentUsingRate(10));			
		}
		catch(COMException ex)
		{
			Console.WriteLine("Loan denied: {0}", (LoanError)ex.HResult);
		}
	}
}