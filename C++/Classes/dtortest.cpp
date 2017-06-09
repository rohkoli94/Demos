#include <iostream>

using namespace std;

class Interval
{
public:
	//constructor which can be called with no argument, one argument
	//or two arguments but cannot be used for conversion
	explicit Interval(long min=0, long sec=0)
	{
		seconds = 60 * min + sec;
		++count;
	}
	
	void SetTime(long value)
	{
		seconds = value;
	}

	long GetTime()
	{
		return seconds;
	}
	
	//instance method - it is invoked on object (using . operator)
	//receives 'this' argument and as such it can refer to other instance members
	void Print()
	{
		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}
	
	//class method - it is invoked on the class (using :: operator)
	//does not receive 'this' argument and as such it cannot refer to instance members
	static int CountInstances()
	{
		return count;
	}

	~Interval()
	{
		count--;
	}
private:
	long seconds; //instance field - each object receives its own value of this field 
	static int count; //class field - all objects share a single value of this field
};

int Interval::count = 0; //allocating value of class field

void Run(void)
{
	cout << "activating John's Interval" << endl;
	Interval john(4, 10);
	cout << "John's interval = ";
	john.Print();
	cout << "deactivating John's Interval" << endl;
}

int main(void)
{
	cout << "activating Jack's Interval" << endl;
	Interval jack;
	jack.SetTime(125);
	cout << "Jack's interval = ";
	jack.Print();

	Run();

	cout << "activating Jeff's Interval" << endl;
	Interval jeff(4); 
	cout << "Jeff's interval = ";
	jeff.Print();

	cout << "Number of active Interval instances = "
		 << Interval::CountInstances()
		 << endl;

	cout << "deactivating Jeff's Interval" << endl;
	cout << "deactivating Jack's Interval" << endl;
}

