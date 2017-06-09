#include "interval.h"
#include <iostream>
#include <list>

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
	intervals.push_front(Interval(2, 30));

	for(Store::iterator i = intervals.begin(); i != intervals.end(); ++i)
		cout << *i << "\t" << i->GetTime() << endl;

	Store::iterator j = intervals.begin();
	++j; 
	++j;
	cout << "Third interval = " << *j << endl;

}


