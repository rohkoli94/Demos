#include <iostream>

using namespace std;

class Interval
{
public:
	Interval()
	{
		minutes = 0;
		seconds = 0;
	}

	Interval(long min, long sec)
	{
		minutes = min + sec / 60;
		seconds = sec % 60;
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

	long operator[](int index) const
	{
		return index ? minutes : seconds;
	}

	operator float()
	{
		return minutes + seconds / 60.0;
	}
private:
	long minutes;
	long seconds;
};

int main(void)
{
	Interval a(2, 105);
	a.Print();
	cout << "Above interval has "
		 << a[1] << " minutes and "
		 << a[0] << " seconds."
		 << endl;
	
	float b = a;
	cout << b << endl;
}


