using Banking;
using System;

static class Program
{
	public static void Main()
	{
		Account jack = Banker.OpenCurrentAccount();
		jack.Deposit(20000);
	
		Account jill = Banker.OpenSavingsAccount();
		jill.Deposit(10000);

		try
		{
			Console.Write("Amount to transfer: ");
			double amt = Convert.ToDouble(Console.ReadLine());
			jill.Transfer(amt, jack);
			Console.WriteLine("Funds transferred.");
		}
		catch(AccountingException ex) when (ex.Cause == FaultType.InsufficientFunds)
		{
			Console.WriteLine("Transfer failed due to lack of funds!");
		}
		catch(Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		Console.WriteLine($"Jack's Account ID is {jack.Id} and Balance is {jack.Balance:0.00}");
		Console.WriteLine($"Jill's Account ID is {jill.Id} and Balance is {jill.Balance:0.00}");
	}
}