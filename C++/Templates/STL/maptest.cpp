#include "interval.h"
#include <iostream>
#include <string>
#include <map>

using namespace std;

typedef map<string, Interval> Store;

int main(void)
{
	Store intervals;
	intervals.insert(make_pair("monday", Interval(3, 41)));
	intervals.insert(make_pair("tuesday", Interval(7, 32)));
	intervals.insert(make_pair("wednesday", Interval(4, 53)));
	intervals.insert(make_pair("thursday", Interval(5, 24)));
	intervals.insert(make_pair("friday", Interval(6, 15)));
	intervals.insert(make_pair("monday", Interval(2, 10)));

	for(Store::iterator i = intervals.begin(); i != intervals.end(); ++i)
		cout << i->first << " = " << i->second << endl;

	string k;
	cout << "Key: ";
	cin >> k;

	Store::iterator j = intervals.find(k);
	if(j != intervals.end())
		cout << "Value = " << j->second << endl;
	else
		cout << "No such key!" << endl;

}


