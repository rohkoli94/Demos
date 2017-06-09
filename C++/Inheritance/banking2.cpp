#include "banking2.h"

namespace Banking
{	
	class CurrentAccount : public Account
	{
	public:
		void Deposit(double);
		void Withdraw(double) throw(InsufficientFunds);
	};

	class SavingsAccount : public Account, public Profitable
	{
	public:
		SavingsAccount();
		void Deposit(double);
		void Withdraw(double) throw(InsufficientFunds);
		double GetInterest(short) const;
	};
	
	double Account::Balance() const
	{
		return balance;
	}

	void Account::Transfer(double amount, Account* that) throw(InsufficientFunds)
	{
		if(this != that)
		{
			this->Withdraw(amount);
			that->Deposit(amount);
		}
	}

	Account::Account()
	{
		balance = 0;
	}

	void CurrentAccount::Withdraw(double amount) throw(InsufficientFunds)
	{
		balance -= amount;
	}

	void CurrentAccount::Deposit(double amount)
	{
		if(balance < 0)
			amount *= 0.9;
		balance += amount;
	}

	SavingsAccount::SavingsAccount()
	{
		balance = 10000;
	}

	void SavingsAccount::Withdraw(double amount) throw(InsufficientFunds)
	{
		if(balance - amount < 10000)
			throw InsufficientFunds();
		balance -= amount;
	}

	void SavingsAccount::Deposit(double amount)
	{
		balance += amount;
	}

	double SavingsAccount::GetInterest(short period) const
	{
		double rate = balance < 20000 ? 4 : 4.5;
		
		return balance * period * rate / 100;
	}

	Account* OpenCurrentAccount()
	{
		return new CurrentAccount;
	}

	Account* OpenSavingsAccount()
	{
		return new SavingsAccount;
	}

	void CloseAccount(Account* acc)
	{
		delete acc;
	}
}


