class ThreadCoordTest{

	private static int value = 0;

	private static void consume(){
		System.out.printf("Consumer ready...%n");
		System.out.printf("Processed value = %d%n", value * value);
	}

	private static void produce(){
		System.out.printf("Producer ready...%n");
		int result = Worker.doWork();
		value = result;
	}

	public static void main(String[] args) throws Exception{
		produce();
		consume();
	}
}












