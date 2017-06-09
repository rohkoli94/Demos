#include <iostream>

using namespace std;

double Average(double first, double second, double& dev)
{
	dev = first > second ? (first - second) / 2 : (second - first) / 2;

	return (first + second) / 2;
}

int main(void)
{
	double a, b, c, d;

	cout << "Enter two real values: ";
	cin >> b >> c;

	a = Average(b, c, d);

	cout << "Average is " << a 
		 << " with the deviation of " << d
		 << endl;
}

/*
long UsePtr(void)
{
	long m = 23;
	long n = 32;
	long* pm = &m;
	long* pn = &n;

	return (*pm) * (*pn);
}

long UseRef(void)
{
	long m = 23;
	long n = 32;
	long& rm = m;
	long& rn = n;

	return rm * rn;
}
*/


