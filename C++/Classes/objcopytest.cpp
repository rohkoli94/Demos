#include <iostream>

using namespace std;

class Interval
{
public:
	//default constructor 
	Interval()
	{
		minutes = 0;
		seconds = 0;
		cout << "Interval default instance initialized" << endl;
	}
	
	//paramterized constructor
	Interval(long min, long sec)
	{
		minutes = min + sec / 60;
		seconds = sec % 60;
		cout << "Interval instance initialized" << endl;
	}

	//copy constructor
	Interval(const Interval& other)
	{
		minutes = other.minutes;
		seconds = other.seconds;
		cout << "Interval instance copy initialized" << endl;
	}

	~Interval()
	{
		cout << "Interval instance finalized" << endl;
	}

	void operator=(const Interval& other) 
	{
		minutes = other.minutes;
		seconds = other.seconds;
		cout << "Interval instance assigned" << endl;
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

class Journey
{
public:
	Journey(float dis, const Interval& dur) : duration(dur)
	{
		distance = dis;
		//duration = dur;
		cout << "Journey instance initialized" << endl;
	}

	float Speed() const
	{
		return 3.6 * distance / duration.GetTime();
	}

	~Journey()
	{		
		cout << "Journey instance finalized" << endl;
	}

private:
	float distance;
	Interval duration;
};

void Run(void)
{
	Interval i(3, 20);
	Journey j(500, i);

	cout << "Speed = " << j.Speed() << endl;
}

int main(void)
{
	/*
	Interval a(3, 45);
	Interval b = a; //Interval b(a)
	Interval c;
	c = b; //c.operator=(b) 
	*/

	cout << "Journey begins..." << endl;
	Run();
	cout << "Journey ends" << endl;
}


