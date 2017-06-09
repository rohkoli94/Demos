class SwitchStringTest{

	private static double rent(int stay, String room){
		float rate;
		switch(room){
			case "ECONOMY":
				rate = 475;
				break;
			case "BUSINESS":
				rate = 625;
				break;
			case "EXECUTIVE":
				rate = 725;
				break;
			default:
				rate = 975;
		}
		return 1.12 * rate * stay;
	}

	public static void main(String[] args){
		int days = args.length > 0 ? Integer.parseInt(args[0]) : 3;
		System.out.printf("Payment for ECONOMY type room is %.2f%n", rent(days, "ECONOMY"));
		System.out.printf("Payment for BUSINESS type room is %.2f%n", rent(days, "BUSINESS"));
		System.out.printf("Payment for EXECUTIVE type room is %.2f%n", rent(days, "EXECUTIVE"));
		System.out.printf("Payment for DELUXE type room is %.2f%n", rent(days, "DELUXE"));
	}
}


