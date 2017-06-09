#include <iostream>
#include <string>

using namespace std;

int nidx = 0;

template<typename Any>
void PrintIndexed(Any value)
{
	cout << "[" << (++nidx) << "] = " << value << endl;
}

template<> //explicit specialization of PrintIndexed function template for Any=bool
void PrintIndexed(bool value)
{	
	cout << "[" << (++nidx) << "] = " << (value ? "true" : "false") << endl;
}

int main(void)
{
	long l = 45;
	PrintIndexed(l);

	double d = 5.4;
	PrintIndexed(d);

	string s = "sunday";
	PrintIndexed(s);

	string t = "tuesday";
	PrintIndexed(t); //reusing template function

	bool a = true;
	PrintIndexed(a); //calling specialized PrintIndexed 
}


