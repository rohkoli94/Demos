#ifndef PAYROLL1_H
#define PAYROLL1_H

#include <iostream>

namespace Payroll
{
	class Employee
	{
	public:
		explicit Employee(long h=0, float r=50)
		{
			hours = h;
			rate = r;
			#ifdef _TESTING
			std::cout << "-- Employee instance initialized." << std::endl;
			#endif
		}
	
		long GetHours() const
		{
			return hours;
		}

		void SetHours(long value)
		{
			hours = value;
		}

		float GetRate() const
		{
			return rate;
		}

		void SetRate(float value)
		{
			rate = value;
		}
		
		double GetNetIncome() const
		{
			double income = hours * rate;
			long ot = hours - 180;

			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		~Employee()
		{
			#ifdef _TESTING
			std::cout << "-- Employee instance finalized." << std::endl;
			#endif
		}
	private:
		long hours;
		float rate;
	};

	class SalesPerson : public Employee
	{
	public:
		SalesPerson(long h, float r, double s) : Employee(h, r)
		{
			sales = s;
			#ifdef _TESTING
			std::cout << "-- SalesPerson instance initialized." << std::endl;
			#endif
		}
		
		double GetSales() const
		{
			return sales;
		}

		void SetSales(double value)
		{
			sales = value;
		}

		//hiding member function of base class
		double GetNetIncome() const
		{
			double income = Employee::GetNetIncome();

			if(sales >= 20000)
				income += 0.05 * sales;

			return income;
		}

		~SalesPerson()
		{
			#ifdef _TESTING
			std::cout << "-- SalesPerson instance finalized." << std::endl;
			#endif	
		}
	private:
		double sales;
	};

}

#endif


