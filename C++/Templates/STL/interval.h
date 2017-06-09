#ifndef INTERVAL_H
#define INTERVAL_H

#include <iostream>

class Interval
{
public:
	Interval(long min=0, long sec=0)
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

	bool operator==(const Interval& other) const
	{
		return GetTime() == other.GetTime();
	}

	bool operator<(const Interval& other) const
	{
		return GetTime() < other.GetTime();
	}

private:
	long minutes;
	long seconds;

	friend std::ostream& operator<<(std::ostream& out, const Interval& val);
};

std::ostream& operator<<(std::ostream& out, const Interval& val)
{
	if(val.seconds < 10)
		out << val.minutes << ":0" << val.seconds;
	else
		out << val.minutes << ":" << val.seconds;

	return out;
}
#endif
