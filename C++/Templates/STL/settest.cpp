#include "interval.h"
#include <iostream>
#include <set>
#include <functional>

using namespace std;

//typedef set<Interval> Store;
typedef set<Interval, greater<Interval> > Store;

bool operator>(const Interval& lhs, const Interval& rhs)
{
	return rhs < lhs;
}

int main(void)
{
	Store intervals;
	intervals.insert(Interval(3, 41));
	intervals.insert(Interval(7, 32));
	intervals.insert(Interval(4, 53));
	intervals.insert(Interval(5, 24));
	intervals.insert(Interval(6, 15));
	intervals.insert(Interval(2, 101));

	for(Store::iterator i = intervals.begin(); i != intervals.end(); ++i)
		cout << *i << "\t" << i->GetTime() << endl;

}


