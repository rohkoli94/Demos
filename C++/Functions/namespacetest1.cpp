int age = 32;

namespace Jack
{	
	int age = 19;
}

int main(void)
{
	int age = 23;

	return age + ::age + Jack::age;
}



