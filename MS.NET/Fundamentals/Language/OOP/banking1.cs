using System;

namespace Banking
{
	public enum FaultType {InsufficientFunds, IllegalTransfer}

	public class AccountingException : ApplicationException
	{
		public FaultType Cause {get; private set;}

		public AccountingException(FaultType ft) : base(ft.ToString())
		{
			Cause = ft;
		}
	}

	public abstract class Account
	{
		public int Id {get; internal set;}

		public double Balance {get; protected set;}

		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account that)
		{
			if(ReferenceEquals(this, that))
				throw new AccountingException(FaultType.IllegalTransfer);
			
			this.Withdraw(amount);
			that.Deposit(amount);
		}
	}

	//non inheritable class
	sealed class CurrentAccount : Account
	{
		public override void Deposit(double amount)
		{
			Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}
	}

	sealed class SavingsAccount : Account
	{
		const double MinBalance = 10000;
		
		internal SavingsAccount()
		{
			Balance = MinBalance;
		}

		public override void Deposit(double amount)
		{
			Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			if(Balance - amount < MinBalance)
				throw new AccountingException(FaultType.InsufficientFunds);
			
			Balance -= amount;
		}
	}

	public static class Banker
	{
		private static int nid = Environment.TickCount % 1000000;

		public static Account OpenCurrentAccount()
		{
			CurrentAccount acc = new CurrentAccount();
			acc.Id = 1000000 + nid++;
			
			return acc;
		}

		public static Account OpenSavingsAccount()
		{
			SavingsAccount acc = new SavingsAccount();
			acc.Id = 2000000 + nid++;
			
			return acc;
		}
	}
}