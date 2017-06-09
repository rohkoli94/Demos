class ThreadCoordTest{

	private volatile static int value = 0;
	private static Object coordinator = new Object();

	private static void consume() throws InterruptedException{
		System.out.printf("Consumer<%x> ready...%n", Thread.currentThread().hashCode());
		//while(value == 0) Thread.yield();
		synchronized(coordinator){
			coordinator.wait();
			System.out.printf("Processed value = %d%n", value * value);
		}
	}

	private static void produce(){
		System.out.printf("Producer<%x> ready...%n", Thread.currentThread().hashCode());
		int result = Worker.doWork();
		synchronized(coordinator){
			value = result;
			coordinator.notify();
		}
	}

	public static void main(String[] args) throws Exception{
		Thread producer = new Thread(ThreadCoordTest::produce);
		producer.start();
		consume();
	}
}












