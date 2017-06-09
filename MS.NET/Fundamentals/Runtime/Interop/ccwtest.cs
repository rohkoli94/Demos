using FinanceLib;
using System;
using System.Runtime.InteropServices;

[ComImport]
[Guid("1A87402F-A9F3-449F-ACB3-714A9275BEE0")]
class ReducingBalanceLoanClass {}

class CarLoan : ILoanScheme 
{
	public float GetInterestRate(short period)
	{
		return period < 3 ? 12 : 15;
	}
}

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
			//passing managed object to a COM interface transfers its COM callable wrapper
			//which forwards COM calls back to that managed object 
			Console.WriteLine("E.M.I: {0:0.00}", loan.GetInstallmentForScheme(new CarLoan()));			
		}
		catch(COMException ex)
		{
			Console.WriteLine("Loan denied: {0}", (LoanError)ex.HResult);
		}
	}
}