class AutoBoxTest1{

	private static Double lookup(String name){
		String[] names = {"jack", "jill", "john", "jane", "jeff"};
		double[] balances = {9000, 12000, 18000, 15000, 6000};
		for(int i = 0; i < names.length; ++i){
			if(names[i].equals(name))
				//auto-boxing
				return balances[i]; //Double.valueOf(balances[i]);				
		}
		return null;
	}

	public static void main(String[] args){
		Double result = lookup(args[0]);
		if(result == null)
			System.out.println("No such name!");
		else{
			//unboxing
			double bal = result; //result.doubleValue();
			System.out.printf("Balance = %.2f%n", bal);
		}
	}
}


