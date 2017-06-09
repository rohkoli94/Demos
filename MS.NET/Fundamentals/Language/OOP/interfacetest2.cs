using System;

interface ITaxPayer
{
	int PIN {get;}
	double GetAnnualIncome();
}

static class TaxPayers
{
	//extension method - a static method that can be invoked as an 
	//instance method of its first this qualified argument type
	public static double GetIncomeTax(this ITaxPayer that, int age)
	{
		double ex = that.GetAnnualIncome() - 120000;
		float tr = age < 60 ? 0.15f : 0.12f;
	
		return ex > 0 ? tr * ex : 0;
	}
}

class Consultant : Payroll.Employee, ITaxPayer
{
	internal Consultant(int h, float r) : base(h, r) {}

	public int PIN
	{
		get { return Id + 100001; }
	}

	public double GetAnnualIncome()
	{
		return 12 * GetNetIncome() + 25000;
	}	
}

class Dealer : ITaxPayer
{
	private int pin;
	private double sales;

	internal Dealer(int p, double s)
	{
		pin = p;
		sales = s;
	}

	public int PIN => pin;

	public double GetAnnualIncome()
	{
		return 0.2 * sales;
	}
}

static class Program
{
	public static void Main()
	{
		Consultant jill = new Consultant(190, 250);
		Dealer jack = new Dealer(202002, 5200000);
		
		Console.WriteLine("Jill's PIN is {0} and Tax is {1:0.00}", jill.PIN, jill.GetIncomeTax(36)); //TaxPayers.GetIncomeTax(jill, 36)
		Console.WriteLine("Jack's PIN is {0} and Tax is {1:0.00}", jack.PIN, jack.GetIncomeTax(63));
	}
}