class BoundedTypeTest{

	private static<T extends Comparable<T>> T select(T first, T second){
		if(first.compareTo(second) > 0)
			return first;
		return second;
	}

	public static void main(String[] args){
		String ss = select("Monday", "Tuesday");
		System.out.printf("Selected String = %s%n", ss);
		double sd = select(4.3, 3.2);
		System.out.printf("Selected double = %s%n", sd);
		Interval si = select(new Interval(3, 45), new Interval(4, 56));
		System.out.printf("Selected Interval = %s%n", si);
	}
}


