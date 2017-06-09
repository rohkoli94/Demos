#include <iostream>
#include <cmath>

using namespace std;

double GetIncome(double invest, short duration, float rate=7)
{
	double amount = invest * pow(1 + rate / 100, duration);

	return amount - invest;
}

int main(void)
{
	double p;
	short n;

	cout << "Enter investment and duration: ";
	cin >> p >> n;

	cout << "Income in GOLD scheme: "
		 << GetIncome(p, n, 8.5)
		 << endl;
	cout << "Income in SILVER scheme: "
		 << GetIncome(p, n) //GetIncome(p, n, 7) 
		 << endl;
}

