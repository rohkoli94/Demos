#include "payroll2.h"
#include <iostream>
#include <typeinfo>

using namespace Payroll;
using namespace std;

class SalesAgent : public SalesPerson
{
public:
	SalesAgent(double s) : SalesPerson(0, 0, s) {}

	double GetNetIncome() const
	{
		return 0.15 * GetSales();
	}

};

double GetTotalSales(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
		SalesPerson* sp = dynamic_cast<SalesPerson*>(group[i]);
		if(sp)
			total += sp->GetSales();
	}

	return total;
}

int main(void)
{
	Employee** dept = new Employee*[5];
	dept[0] = new Employee(186, 52);
	dept[1] = new Employee(190, 110);
	dept[2] = new SalesPerson(175, 65, 55000);
	dept[3] = new Employee(185, 75);
	dept[4] = new SalesAgent(45000);

	cout << "Total sales income = "
		 << GetTotalSales(dept, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
		delete dept[i];

	delete[] dept;
}



