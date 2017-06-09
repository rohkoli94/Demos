#include <iostream>

extern double Power(double, long);

int main(void)
{
	using namespace std;

	double b;
	long i;

	cout << "Enter base and index: ";
	cin >> b >> i;

	cout << "Result = "
		 << Power(b, i)
		 << endl;
}


