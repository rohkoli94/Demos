#include <iostream>

using namespace std;

class Interval
{
public:
	void SetTime(long value) 
	//void Interval::SetTime(Interval* this, long value)
	{
		minutes = value / 60; //this->minutes = value / 60;
		seconds = value % 60; //this->seconds = value % 60;
	}

	long GetTime()
	{
		return 60 * minutes + seconds;
	}

	void Print()
	{
		if(seconds < 10)
			cout << minutes << ":0" << seconds << endl;
		else
			cout << minutes << ":" << seconds << endl;
	}
private:
	long minutes;
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


