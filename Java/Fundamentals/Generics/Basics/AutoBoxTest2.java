class AutoBoxTest2{

	private static Object select(int selector, Object first, Object second){
		if(selector < 0)
			return first;
		return second;
	}

	public static void main(String[] args){
		int s = Integer.parseInt(args[0]);
		String ss = (String)select(s, "Monday", "Tuesday");
		System.out.printf("Selected String = %s%n", ss);
		double sd = (double)select(s, 4.3, 3.2);
		System.out.printf("Selected double = %s%n", sd);
		int si = (int)select(s, 123456, "ABCDEF");
		System.out.printf("Selected int = %s%n", si);
	}
}


