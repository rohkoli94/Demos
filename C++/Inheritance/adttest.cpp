#include "banking1.h"
#include <iostream>

using namespace Banking;
using namespace std;

int main(void)
{
	Account* jack = new CurrentAccount;
	jack->Deposit(25000);
	
	Account* jill = new SavingsAccount;
	jill->Deposit(15000);

	double amt;
	cout << "Amount to transfer: ";
	cin >> amt;

	try
	{
		jill->Transfer(amt, jack);
		cout << "Transfer succeeded." << endl;
	}
	catch(InsufficientFunds)
	{
		cout << "Transfer failed due to lack of funds!" << endl;
	}

	cout << "Jack's balance is " << jack->Balance() << endl;
	cout << "Jill's balance is " << jill->Balance() << endl;

	delete jill;
	delete jack;
}


