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
	for(SimpleStack<double>::Iterator i = a.begin(); i != a.end(); ++i)
		cout << *i << endl;

	double total = 0;
	for(SimpleStack<double>::Iterator i = a.begin(); i != a.end(); ++i)
		total += *i;
	cout << "Total = " << total << endl;

	cout << endl;

	SimpleStack<string> b;
	b.Push("monday");
	b.Push("tuesday");
	b.Push("wednesday");
	b.Push("thursday");
	b.Push("friday");
	for(SimpleStack<string>::Iterator i = b.begin(); i != b.end(); ++i)
		cout << i->size() << "\t" << *i << endl;

}


