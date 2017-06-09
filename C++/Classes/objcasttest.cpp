#include <iostream>

using namespace std;

class Interval
{
public:
	explicit Interval(long min=0, long sec=0)
	{
		id = 0;
		seconds = 60 * min + sec;
	}

	int GetId() const 
	{
		static int nid = 1;

		if(id == 0)
			id = ++nid; //modifying mutable field

		return id;
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

	static const Interval& First()
	{
		static Interval first;

		first.id = 1;

		return first;
	}

private:
	mutable int id; //a field that can be modified in a const method 
	long seconds;
};

void Show(const Interval& val)
{
	cout << "Interval " << val.GetId() << " = ";
	val.Print();
}

int main(void)
{
	Interval jack(1, 65);
	Show(jack);

	Interval& jill = const_cast<Interval&>(Interval::First());
	jill.SetTime(200);
	
	struct _Interval
	{
		int id;
		long seconds;
	};

	_Interval& _jill = reinterpret_cast<_Interval&>(jill);
	_jill.id = 10;
	
	Show(jill);

}

