interface TaxPayer{

	int pin();

	double getAnnualIncome();

	//extension method - an added method whose implementation is shared by all classes
	//which already inherit from this interface
	default double getIncomeTax(int age){
		float tr = age < 60 ? 0.15f : 0.10f;
		double ti = getAnnualIncome() - 120000;
		return ti > 0 ? tr * ti : 0;
	}
}

class Consultant extends payroll.Employee implements TaxPayer{

	public Consultant(int h, float r){
		super(h, r);
	}

	public int pin(){
		return 1000000 + getId();
	}

	public double getAnnualIncome(){
		return 12 * getNetIncome() + 25000;
	}

}

class Dealer implements TaxPayer{
	
	private int id;
	private double sales;

	public Dealer(int i, double s){
		id = i;
		sales = s;
	}

	public int pin(){
		return id;
	}

	public double getAnnualIncome(){
		return 0.15 * sales;
	}
}

class InterfaceTest2{

	public static void main(String[] args){
		TaxPayer jill = new Consultant(190, 200);
		TaxPayer jack = new Dealer(234567, 4000000);
		System.out.printf("Jill's income tax: %.2f%n", jill.getIncomeTax(36));
		System.out.printf("Jack's income tax: %.2f%n", jack.getIncomeTax(63));
	}
}

