#include "interval.h"
#include <iostream>
#include <stack>
#include <list>

using namespace std;

//typedef stack<Interval> Store;
typedef stack<Interval, list<Interval> > Store;

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
		cout << intervals.top() << endl;
		intervals.pop();
	}
}


