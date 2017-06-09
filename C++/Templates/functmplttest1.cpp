#include <iostream>
#include <string>

using namespace std;

/*
void Swap(long& first, long& second)
{
	long third = first;

	first = second;
	second = third;
}

void Swap(double& first, double& second)
{
	double third = first;

	first = second;
	second = third;
}
*/

template<typename T> //Swap function template 
void Swap(T& first, T& second)
{
	T third = first;

	first = second;
	second = third;
}

int main(void)
{
	long l1 = 23, l2 = 32;
	cout << "Original long values = " << l1 << ", " << l2 << endl;
	Swap<long>(l1, l2); //calling templated Swap function with T=long
	cout << "Swapped long values = " << l1 << ", " << l2 << endl;

	double d1 = 4.3, d2 = 3.4;
	cout << "Original double values = " << d1 << ", " << d2 << endl;
	Swap(d1, d2); //Swap<double>(d1, d2); //type deduction from arguments 
	cout << "Swapped double values = " << d1 << ", " << d2 << endl;

	string s1 = "monday", s2 = "tuesday";
	cout << "Original string values = " << s1 << ", " << s2 << endl;
	Swap(s1, s2);
	cout << "Swapped string values = " << s1 << ", " << s2 << endl;

	//Swap(l1, d1);
}


