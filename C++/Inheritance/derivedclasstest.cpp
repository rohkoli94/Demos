#include "payroll1.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetIncomeTax(const Employee& entry)
{
	double i = entry.GetNetIncome(); //Employee::GetNetIncome(&entry)

	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

double GetIncomeTax(const SalesPerson& entry)
{
	double i = entry.GetNetIncome(); //SalesPerson::GetNetIncome(&entry)

	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

int main(void)
{
	Employee jack;
	jack.SetHours(186);
	jack.SetRate(52);
	cout << "Jack's income is "
		 << jack.GetNetIncome()
		 << " and tax is "
		 << GetIncomeTax(jack)
		 << endl;

	SalesPerson jill(186, 52, 34000);
	cout << "Jill's income is "
		 << jill.GetNetIncome()
		 << " and tax is "
		 << GetIncomeTax(jill)
		 << endl;


}



