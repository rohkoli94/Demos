#include <iostream>
#include <string>

using namespace std;

struct BadName{};

int Search(string entry, string entries[], int count)
{
	if(entry.size() < 4)
	{
		BadName bn;
		throw bn;
	}

	for(int i = 0; i < count; ++i)
	{
		if(entries[i] == entry)
			return i;
	}

	throw entry;
}

void Run(void)
{
	string names[] = {"jack", "jill", "john", "jane"};
	long balances[] = {13000, 19000, 17000, 3000};

	string name;
	cout << "Name: ";
	cin >> name;

	int i = Search(name, names, 4);
	cout << "Balance = " << balances[i] << endl;
}

int main(void)
{
	cout << "Welcome to our bank" << endl;
	try
	{
		Run();
	}
	catch(...)
	{
		cout << "Operation failed!" << endl;
	}
	cout << "Goodbye from our bank" << endl;
}

