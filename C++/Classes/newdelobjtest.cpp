#include <iostream>

using namespace std;

class Interval
{
public:
	Interval()
	{
		minutes = 0;
		seconds = 0;
		cout << "Interval default instance initialized" << endl;
	}

	Interval(long min, long sec)
	{
		minutes = min + sec / 60;
		seconds = sec % 60;
		cout << "Interval instance initialized" << endl;
	}
	
	~Interval()
	{
		cout << "Interval instance finalized" << endl;
	}
	void SetTime(long value) 
	{
		minutes = value / 60; 
		seconds = value % 60; 
	}

	long GetTime() const
	{
		return 60 * minutes + seconds;
	}

	void Print() const
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

float GetSpeed(float distance, const Interval& duration)
{
	return 3.6 * distance / duration.GetTime();
}

int main(void)
{
	Interval* jack = new Interval; //dynamic activation using default constructor
	jack->SetTime(125);
	cout << "Jack's interval = ";
	jack->Print();
	cout << "Jack's speed = "
		 << GetSpeed(500, *jack)
		 << endl;

	Interval* jeff = new Interval(3, 20); //dynamic activation using parameterized constructor 
	cout << "Jeff's interval = ";
	jeff->Print();
	cout << "Jeff's speed = "
		 << GetSpeed(500, *jeff)
		 << endl;

	delete jeff; //explicit deactivation 
	delete jack;
}


