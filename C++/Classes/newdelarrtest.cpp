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

int main(void)
{
	int n;
	cout << "Number of intervals: ";
	cin >> n;

	Interval* store = new Interval[n];

	for(int i = 0; i < n; ++i)
	{
		store[i].SetTime(100 + 25 * i);
		store[i].Print();
	}

	//return ((int*)store)[-1];
	
	delete[] store;
}


