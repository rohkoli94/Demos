//#define _TESTING
#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetAverageIncome(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
		total += group[i]->GetNetIncome();
	}

	return total / count;
}

int main(void)
{
	Employee* dept[5];
	dept[0] = new Employee(186, 52);
	dept[1] = new Employee(190, 110);
	dept[2] = new SalesPerson(175, 65, 55000);
	dept[3] = new Employee(185, 75);
	dept[4] = new SalesPerson(168, 54, 45000);

	cout << "Average income = "
		 << GetAverageIncome(dept, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
		delete dept[i];

}



