#include "banking1.h"

namespace Banking
{
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
}


