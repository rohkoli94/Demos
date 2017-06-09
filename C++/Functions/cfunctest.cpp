#include <iostream>

using namespace std;

extern "C" int CountPrimes(long, long);

int main(void)
{
	long m, n;

	cout << "Enter lower and upper limit: ";
	cin >> m >> n;

	cout << "Number of primes = "
		 << CountPrimes(m, n)
		 << endl;
}


