#include "generics.h"
#include <iostream>
#include <string>

using namespace Generics;
using namespace std;

int main(void)
{
	SimpleStack<double> a;
	a.Push(43.1);
	a.Push(35.2);
	a.Push(71.3);
	a.Push(19.4);
	//a.Push("xyz");
	while(!a.Empty())
		cout << a.Pop() << endl;

	double total = 0;
	while(!a.Empty())
		total += a.Pop();
	cout << "Total = " << total << endl;

	cout << endl;

	SimpleStack<string> b;
	b.Push("monday");
	b.Push("tuesday");
	b.Push("wednesday");
	b.Push("thursday");
	b.Push("friday");
	while(!b.Empty())
		cout << b.Pop() << endl;

	//SimpleStack<string> c = b;
}


