#include <iostream>
#include <string>

using namespace std;

int nidx = 0;

template<typename V>
class IndexedValue //IndexedValue class template
{
public:
	IndexedValue(const V& val) : value(val)
	{
		index = ++nidx;
	}

	void Print() const
	{
		cout << "[" << index << "] = " << value << endl;
	}
private:
	int index;
	V value;
};

template<> //full specialization of IndexedValue class template
class IndexedValue<bool>
{
public:
	IndexedValue(bool val)
	{
		index = ++nidx;
		value = val;
	}
	
	void Print() const
	{
		cout << "[" << index << "] = " << (value ? "true" : "false") << endl;
	}

private:
	int index;
	bool value;
};

int main(void)
{
	IndexedValue<double> a(3.45); //instantiating IndexedValue templated class with V=double
	a.Print();

	IndexedValue<string> b("monday");
	b.Print();

	IndexedValue<bool> c(true); //instantiating specialized IndexedValue templated class 
	c.Print();
}

