#include "interval.h"
#include <iostream>
#include <vector>
#include <algorithm>
#include <functional>
#include <utility>

using namespace std;
using rel_ops::operator>;

typedef vector<Interval> Store;

int main(void)
{
	Store intervals;
	intervals.push_back(Interval(3, 41));
	intervals.push_back(Interval(7, 32));
	intervals.push_back(Interval(4, 53));
	intervals.push_back(Interval(5, 24));
	intervals.push_back(Interval(6, 15));

	//sort(intervals.begin(), intervals.end());
	sort(intervals.begin(), intervals.end(), greater<Interval>());

	for(Store::iterator i = intervals.begin(); i != intervals.end(); ++i)
		cout << *i << "\t" << i->GetTime() << endl;
}


