class TryCatchTest{
	
	private static void run(String[] args){
		try{
			double value = Double.parseDouble(args[0]);
			System.out.printf("Square of %s is %s%n", value, value * value);
		}catch(NumberFormatException e){
			System.out.println("Bad input!");
		}catch(ArrayIndexOutOfBoundsException e){
			System.out.println("No input!");
		}
	}

	public static void main(String[] args){
		System.out.println("Welcome User.");
		run(args);
		System.out.println("Goodbye User.");
	}
}


