#include "namespacetest2.h"

int main(void)
{
	using namespace Jack;
	//using namespace Jack::Jill;

	return age + Jill::age;
}

