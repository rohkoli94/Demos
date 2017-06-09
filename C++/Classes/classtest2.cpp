#include <iostream>

using namespace std;

class Interval
{
public:
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

float GetSpeed(float distance, Interval duration)
{
	return 3.6 * distance / duration.GetTime();
}

int main(void)
{
	Interval jack;
	jack.SetTime(125); //Interval::SetTime(&jack, 125)
	cout << "Jack's interval = ";
	jack.Print();
	cout << "Jack's speed = "
		 << GetSpeed(500, jack)
		 << endl;

	Interval jeff;
	jeff.SetTime(200); //Interval::SetTime(&jeff, 200)
	cout << "Jeff's interval = ";
	jeff.Print();
	cout << "Jeff's speed = "
		 << GetSpeed(500, jeff)
		 << endl;
}


