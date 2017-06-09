#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetIncomeTax(const Employee& entry)
{
	//virtual function called through indirection (ref/ptr) will be invoked using dynamic binding
	double i = entry.GetNetIncome(); //entry.vptr->GetNetIncome(&entry)

	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

int main(void)
{
	Employee jack;
	jack.SetHours(186); //Employee::SetHours(&jack, 186)
	jack.SetRate(52);
	cout << "Jack's income is "
		 << jack.GetNetIncome() //Employee::GetNetIncome(&jack)
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



