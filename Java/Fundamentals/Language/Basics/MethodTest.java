class MethodTest{

	private static double getIncome(double invest, int period, float rate){
		double amount = invest * Math.pow(1 + rate / 100, period);
		return amount - invest;
	}

	private static double getIncome(double invest, int period){
		return getIncome(invest, period, 7);
	}

	public static void main(String[] args){
		double p = Double.parseDouble(args[0]);
		int n = Integer.parseInt(args[1]);
		System.out.printf("Income in GOLD scheme: %.2f%n", getIncome(p, n, 8));
		System.out.printf("Income in SILVER scheme: %.2f%n", getIncome(p, n));
	}
}


