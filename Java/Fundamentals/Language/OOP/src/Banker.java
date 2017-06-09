package edu.met.banking;

public class Banker{
	
	private static int nid = (int)(System.currentTimeMillis() % 1000000);

	public static Account openCurrentAccount(){
		CurrentAccount acc = new CurrentAccount();
		acc.id = 1000000 + nid++;
		return acc;
	}

	public static Account openSavingsAccount(){
		SavingsAccount acc = new SavingsAccount();
		acc.id = 2000000 + nid++;
		return acc;
	}

	private Banker(){}
}

