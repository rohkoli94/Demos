#include "generics.h"
#include <iostream>
#include <string>

using namespace Generics;
using namespace std;

//unary predicate as a function 
bool IsOdd(long n)
{
	return n % 2;
}

/*
bool IsSmallerThan(double value, double limit)
{
	return value < limit;
}
*/

//unary predicate as a functor(object of a class with overloaded () operator)
class IsSmallerThan
{
public:
	IsSmallerThan(double lim)
	{
		limit = lim;
	}

	bool operator()(double value) const
	{
		return value < limit;
	}
private:
	double limit;
};

int main(void)
{
	long squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81};
	cout << "Squares" << endl;
	for(int i = 0; i < sizeof(squares) / sizeof(long); ++i)
		cout << squares[i] << endl;
	cout << "Number of odd squares: "	
		 << Count(squares, squares + 9, IsOdd)
		 << endl;

	SimpleStack<double> scores;
	scores.Push(48.1);
	scores.Push(63.2);
	scores.Push(54.3);
	scores.Push(76.4);
	scores.Push(81.5);
	scores.Push(32.6);
	cout << "Scores" << endl;
	for(SimpleStack<double>::Iterator i = scores.begin(); i != scores.end(); ++i)
		cout << *i << endl;
	cout << "Number of low scores: "
		 << Count(scores.begin(), scores.end(), IsSmallerThan(60))
		 << endl;
}


