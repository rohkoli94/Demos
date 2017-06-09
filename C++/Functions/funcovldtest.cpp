#include <iostream>
#include <cmath>

using namespace std;

double GetIncome(double invest, short duration, float rate)
{
	double amount = invest * pow(1 + rate / 100, duration);

	return amount - invest;
}

inline double GetIncome(double invest, short duration)
{
	return GetIncome(invest, duration, duration < 3 ? 6.5 : 7);
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
		 << GetIncome(p, n) //GetIncome(p, n, n < 3 ? 6.5 : 7) 
		 << endl;
}

