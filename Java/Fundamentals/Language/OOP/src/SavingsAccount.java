package edu.met.banking;

final class SavingsAccount extends Account implements Profitable{
	
	static final double MIN_BALANCE = 10000;

	SavingsAccount(){
		balance = MIN_BALANCE;
	}

	public void deposit(double amount){
		balance += amount;
	}

	public void withdraw(double amount) throws InsufficientFundsException{
		if(balance - amount < MIN_BALANCE)
			throw new InsufficientFundsException();
		balance -= amount;
	}

	public double getInterest(int period){
		float rate = balance < 2 * MIN_BALANCE ? MIN_RATE : MIN_RATE + 1;
		return balance * period * rate / 100;
	}
}


