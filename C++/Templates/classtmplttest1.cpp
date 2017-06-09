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

int main(void)
{
	IndexedValue<double> a(3.45); //instantiating IndexedValue templated class with V=double
	a.Print();

	IndexedValue<string> b("monday");
	b.Print();

	IndexedValue<string> c("tuesday");
	c.Print();
}

