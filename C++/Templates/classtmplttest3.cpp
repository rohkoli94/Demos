#include <iostream>
#include <string>

using namespace std;

int nidx = 0;

template<typename I, typename V>
class IndexedValue 
{
public:
	IndexedValue(const I& idx, const V& val) : index(idx), value(val)
	{
	}

	void Print() const
	{
		cout << index << " = " << value << endl;
	}
private:
	I index;
	V value;
};

template<typename V> //partial specialization of IndexedValue class template for I=int
class IndexedValue<int, V>
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
	IndexedValue<string, double> a("monday", 2.34);
	a.Print();

	IndexedValue<int, string> b("tuesday");
	b.Print();

	IndexedValue<string, string> c("wednesday", "march");
	c.Print();

	IndexedValue<int, int> d(56);
	d.Print();
} 

