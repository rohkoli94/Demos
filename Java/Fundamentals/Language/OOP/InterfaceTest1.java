import edu.met.banking.*;

class InterfaceTest1{

	private static void payAnnualInterest(Account[] accounts){
		for(Account acc : accounts){
			if(acc instanceof Profitable){
				Profitable p = (Profitable)acc;
				double i = p.getInterest(1);
				acc.deposit(i);
			}
		}
	}

	public static void main(String[] args){
		Account[] bank = new Account[4];
		bank[0] = Banker.openSavingsAccount();
		bank[0].deposit(5000);
		bank[1] = Banker.openCurrentAccount();
		bank[1].deposit(25000);
		bank[2] = Banker.openCurrentAccount();
		bank[2].deposit(35000);
		bank[3] = Banker.openSavingsAccount();
		bank[3].deposit(35000);
		payAnnualInterest(bank);
		for(Account acc : bank)
			System.out.printf("%d\t%.2f%n", acc.getId(), acc.getBalance());
	}
}


