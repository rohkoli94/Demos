#include <iostream>

using namespace std;

class Interval
{
public:
	Interval(long min, long sec)
	{
		seconds = 60 * min + sec;
	}

	explicit Interval(long sec=0)
	{
		seconds = sec;
	}

	void SetTime(long value)
	{
		seconds = value;
	}

	long GetTime() const 
	{
		return seconds; 
	}
	
	void Print() const
	{
		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}

	Interval operator+(const Interval& other) const
	{
		return Interval(seconds + other.seconds);
	}

	Interval operator++() 
	{
		return Interval(++seconds);
	}

	Interval operator++(int)
	{
		return Interval(seconds++);
	}
	
	Interval operator*(long scalar)
	{
		return Interval(seconds * scalar);
	}

private:
	long seconds;

//a non member function defined by the author of a class 
//which has access to private members of that class
friend Interval operator*(long, const Interval&);
};

Interval operator*(long lhs, const Interval& rhs) 
{
	return Interval(lhs * rhs.seconds);
}

int main(void)
{
	Interval a(4, 30);
	a.Print();
	
	Interval b(3, 40);
	b.Print();

	Interval c = a + b; //a.operator+(b);
	c.Print();

	Interval d = ++c; //c.operator++()
	c.Print();
	d.Print();

	Interval e = d++; //d.operator++(0)
	d.Print();
	e.Print();

	Interval f = 3 * e; //operator*(3,e)
	f.Print();
}

