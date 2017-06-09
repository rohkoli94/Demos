using Payroll;
using System;

static class Program
{
	private static double GetAverageIncome(Employee[] group)
	{
		double total = 0;

		foreach(Employee e in group)
		{
			total += e.GetNetIncome();
		}

		return total / group.Length;
	}

	private static double GetTotalSales(Employee[] group)
	{
		double total = 0;

		foreach(Employee e in group)
		{
			SalesPerson s = e as SalesPerson;
			if(s != null)
				total += s.Sales;
		}

		return total;
	}

	private static double GetTotalBonus(Employee[] group)
	{
		double total = 0;

		foreach(Employee e in group)
		{
			if(e is SalesPerson)
				total += 0.04 * e.GetNetIncome();
			else
				total += 0.09 * e.GetNetIncome();
		}

		return total;
	}


	public static void Main()
	{
		Employee[] department = new Employee[5];
		department[0] = new Employee(186, 52);
		department[1] = new Employee(165, 85);
		department[2] = new SalesPerson(175, 65, 45000);
		department[3] = new Employee(195, 205);
		department[4] = new SalesPerson(190, 55, 55000);
		
		Console.WriteLine("Average Income = {0:0.00}", GetAverageIncome(department));
		Console.WriteLine("Total Sales = {0:0.00}", GetTotalSales(department));
		Console.WriteLine("Total Bonus = {0:0.00}", GetTotalBonus(department));
	}
}