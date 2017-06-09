#include "banking2.h"
#include <iostream>

using namespace Banking;
using namespace std;

void DeductTax(Account* accounts[], int count)
{
	for(int i = 0; i < count; ++i)
	{
		double ext = accounts[i]->Balance() - 25000;
		if(ext > 0)
			accounts[i]->Withdraw(0.05 * ext);
	}
}

void PayAnnualInterest(Account* accounts[], int count)
{
	for(int i = 0; i < count; ++i)
	{
		Profitable* p = dynamic_cast<Profitable*>(accounts[i]);
		if(p)
		{
			double interest = p->GetInterest(1);
			accounts[i]->Deposit(interest);
		}
	}
}

int main(void)
{
	Account* bank[4];
	bank[0] = OpenCurrentAccount();
	bank[0]->Deposit(10000);
	bank[1] = OpenSavingsAccount();
	bank[1]->Deposit(10000);
	bank[2] = OpenSavingsAccount();
	bank[2]->Deposit(20000);
	bank[3] = OpenCurrentAccount();
	bank[3]->Deposit(40000);

	DeductTax(bank , 4);
	PayAnnualInterest(bank, 4);
	for(int i = 0; i < 4; ++i)
	{
		cout << (i + 1) << "\t" << bank[i]->Balance() << endl;
		delete bank[i];
	}
}


