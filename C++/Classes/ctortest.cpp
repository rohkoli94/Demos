#include <iostream>

using namespace std;

class Interval
{
public:
	Interval()
	{
		seconds = 0;	
	}
	
	Interval(long time)
	{
		seconds = time;
	}

	Interval(long sec, long min)
	{
		seconds = 60 * min + sec;
	}
	
	void SetTime(long value)
	{
		seconds = value;
	}

	long GetTime()
	{
		return seconds;
	}
	
	void Print()
	{
		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}
private:
	long seconds;
};


int main(void)
{
	Interval jack; //activation using default constructor(which can be called without any argument)
	jack.SetTime(125);
	cout << "Jack's interval = ";
	jack.Print();

	Interval jeff = 200; //activation using conversion constructor(which can be called with one argument)
	cout << "Jeff's interval = ";
	jeff.Print();
	
	Interval john(66, 5); //activation using parameterized constructor 
	cout << "John's interval = ";
	john.Print();

	Interval jill(330); //using conversion constructor as parameterized constructor
	cout << "Jill's interval = ";
	jill.Print();
}


