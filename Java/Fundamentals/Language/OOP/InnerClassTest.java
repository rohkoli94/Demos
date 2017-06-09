interface Filter{
	boolean allowed(int value);
}

class Counter{

	public static int countIf(int[] values, Filter check){
		int count = 0;
		for(int value : values){
			if(check.allowed(value))
				count += 1;
		}
		return count;
	}
}

class InnerClassTest{

	//inner nested(static) member class
	//it can only access static members of the outer class
	//it can define static and non-static members
	static class OddFilter implements Filter{

		public boolean allowed(int n){
			return (n % 2) == 1;
		}	
	}

	//inner instance(non-static) member class
	//it can access static and non-static members of outer class
	//it can only define non-static members
	class BigFilter implements Filter{
		
		int limit;

		BigFilter(int l){
			limit = l;
		}

		public boolean allowed(int n){
			return n > limit;
		}
	}

	public static void main(String[] args){
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
		System.out.print("All squares:");
		for(int s : squares)
			System.out.printf(" %d", s);
		System.out.println();
		System.out.printf("Number of odd squares: %d%n", Counter.countIf(squares, new InnerClassTest.OddFilter()));
		System.out.printf("Number of big squares: %d%n", Counter.countIf(squares, new InnerClassTest().new BigFilter(20)));
		int l = 10, m = 50; //effectively final as they are accessed in local class
		//passing instance of inner local anonymous class
		System.out.printf("Number of mid squares: %d%n", Counter.countIf(squares, new Filter(){
			public boolean allowed(int n){
				return n > l && n < m; //local variables of outer method are always captured by value
			}
		}));

	}
}

