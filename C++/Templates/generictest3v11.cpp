#include "generics.h"
#include <iostream>
#include <string>

using namespace Generics;
using namespace std;

int main(void)
{
	long squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81};
	cout << "Squares" << endl;
	for(long val : squares)
		cout << val << endl;
	cout << "Number of odd squares: "	
		 << Count(begin(squares), end(squares), [](int n){return n % 2;})
		 << endl;

	SimpleStack<double> scores;
	scores.Push(48.1);
	scores.Push(63.2);
	scores.Push(54.3);
	scores.Push(76.4);
	scores.Push(81.5);
	scores.Push(32.6);
	cout << "Scores" << endl;
	for(double val : scores)
		cout << val << endl;
	double l = 60;
	cout << "Number of low scores: "
		 << Count(begin(scores), end(scores), [l](double s){return s < l;})
		 << endl;
}


