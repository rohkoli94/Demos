#include "interval.h"
#include <iostream>
#include <queue>
#include <vector>
#include <functional>
#include <utility>

using namespace std;
using rel_ops::operator>;

//typedef priority_queue<Interval> Store;
typedef priority_queue<Interval, vector<Interval>, greater<Interval> > Store;

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


