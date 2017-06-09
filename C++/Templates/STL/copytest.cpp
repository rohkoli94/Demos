#include "interval.h"
#include <iostream>
#include <vector>
#include <list>
#include <algorithm>
#include <iterator>

using namespace std;

typedef list<Interval> Store;

int main(void)
{
	Store intervals;
	intervals.push_back(Interval(3, 41));
	intervals.push_back(Interval(7, 32));
	intervals.push_back(Interval(4, 53));
	intervals.push_back(Interval(5, 24));
	intervals.push_back(Interval(6, 15));

	vector<Interval> temp(intervals.size());
	copy(intervals.begin(), intervals.end(), temp.begin());
	sort(temp.begin(), temp.end());
	copy(temp.begin(), temp.end(), intervals.begin());
	copy(intervals.begin(), intervals.end(), ostream_iterator<Interval>(cout, "\n"));
}


