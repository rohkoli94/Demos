#include <iostream>

using namespace std;

class TaxPayer
{
public:
	long PIN() const
	{
		return pin;
	}

	virtual double AnnualIncome() const = 0;

	double IncomeTax() const
	{
		double ex = AnnualIncome() - 120000;
		
		return ex > 0 ? 0.15 * ex : 0;
	}

	virtual ~TaxPayer()
	{
		count--;
	}

	static int Count()
	{
		return count;
	}

protected:
	TaxPayer(long pn)
	{
		pin = pn;
		++count;
	}
private:
	long pin;
	static int count;
};

int TaxPayer::count = 0;

void Print(const TaxPayer* entry)
{
	cout << "P.I.N is "
		 << entry->PIN()
		 << " and Tax is "
		 << entry->IncomeTax()
		 << endl;
}

class Employee : public TaxPayer
{
public:
	Employee(long pn, double sy) : TaxPayer(pn)
	{
		salary = sy;
	}

	double AnnualIncome() const
	{
		return 12 * salary + 25000;
	}
private:
	double salary;
};

class Dealer : public TaxPayer
{
public:
	Dealer(long pn, double ss) : TaxPayer(pn)
	{
		sales = ss;
	}

	double AnnualIncome() const
	{
		return 0.2 * sales;
	}
private:
	double sales;
};

class SalesPerson : public Employee, public Dealer
{
public:
	SalesPerson(long pn, double sy, double ss) : Employee(pn, sy), Dealer(pn, ss)
	{
	}

	double AnnualIncome() const
	{
		return Employee::AnnualIncome() - 25000 + Dealer::AnnualIncome() / 4;
	}
};

int main(void)
{
	Employee* jill = new Employee(123456, 32000);
	Dealer* jack = new Dealer(234567, 5400000);
	SalesPerson* john = new SalesPerson(345678, 15000, 2500000);

	cout << "Jill the Employee: ";
	Print(jill);
	cout << "Jack the Dealer: ";
	Print(jack);
	cout << "John the SalesPerson: ";
	Print(static_cast<Employee*>(john));

	cout << "Number of TaxPayers = "
		 << TaxPayer::Count()
		 << endl;

	delete john;
	delete jack;
	delete jill;
}


