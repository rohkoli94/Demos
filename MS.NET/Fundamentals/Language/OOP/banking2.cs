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

	public interface IProfitable
	{
		double GetInterest(int period);
	}

	public interface ITaxable
	{
		void Deduct();
	}	

	public interface IFineable
	{
		void Deduct();
	}

	sealed class CurrentAccount : Account, ITaxable, IFineable
	{
		public override void Deposit(double amount)
		{
			Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}

		//explicit interface implementation
		void ITaxable.Deduct()
		{
			double extra = Balance - 20000;
			if(extra > 0)
				Balance -= 0.05 * extra;
		}

		void IFineable.Deduct()
		{
			if(Balance < 0)
				Balance *= 1.1;
		}
	}

	sealed class SavingsAccount : Account, IProfitable
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

		public double GetInterest(int period)
		{
			float rate = Balance < 2 * MinBalance ? 4 : 5;
			
			return Balance * period * rate / 100;
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