class VarArgTest{
	
	private static double average(double first, double second){
		return (first + second) / 2;
	}
	
	private static double average(double first, double second, double third){
		return (first + second + third) / 3;
	}

	private static double average(double first, double second, double... remaning){
		double total = first + second;
		for(double value : remaning)
			total += value;
		return total / (2 + remaning.length);
	}

	public static void main(String[] args){
		System.out.printf("Average of two values = %f%n", average(23.4, 16.5));
		System.out.printf("Average of three values = %f%n", average(23.4, 16.5, 29.7));
		System.out.printf("Average of five values = %f%n", average(23.4, 16.5, 29.7, 14.8, 31.3)); //average(23.4, 16.5, new double[]{29.7, 14.8, 31.3})
	}

}


