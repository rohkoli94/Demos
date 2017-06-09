#include "interval.h"
#include <iostream>
#include <queue>
#include <list>

using namespace std;

//typedef queue<Interval> Store;
typedef queue<Interval, list<Interval> > Store;

int main(void)
{
	Store intervals;
	intervals.push(Interval(3, 41));
	intervals.push(Interval(7, 32));
	intervals.push(Interval(4, 53));
	intervals.push(Interval(5, 24));
	intervals.push(Interval(6, 15));

	while(!intervals.empty())
	{
		cout << intervals.front() << endl;
		intervals.pop();
	}
}


