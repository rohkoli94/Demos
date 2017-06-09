#include "payroll2.h"
#include <iostream>
#include <typeinfo>

using namespace Payroll;
using namespace std;
l
double GetTotalSales(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
	    //if(i == 2 || i == 4)
		if(typeid(*group[i]) == typeid(SalesPerson))
		{
			SalesPerson* sp = static_cast<SalesPerson*>(group[i]);
			total += sp->GetSales();
		}
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
	dept[4] = new SalesPerson(168, 54, 45000);

	cout << "Total sales income = "
		 << GetTotalSales(dept, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
		delete dept[i];

	delete[] dept;
}



