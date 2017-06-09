import java.util.concurrent.*;

class ExecutorTest2{

	static class Computation implements Callable<Long>{

		private int low, high;

		Computation(int low, int high){
			this.low = low;
			this.high = high;
		}

		public Long call(){
			long result = 0;
			for(int value = low; value <= high; ++value){
				Worker.doWork(value);
				result += value * value;
			}
			return result;
		}
	}

	public static void main(String[] args) throws Exception{
		ExecutorService pool = Executors.newSingleThreadExecutor();
		Computation c = new Computation(1, 20);
		System.out.print("Processing...");
		Future<Long> r = pool.submit(c);
		while(!r.isDone()){
			System.out.print(".");
			Thread.sleep(500);
		}
		System.out.println("Done!");
		System.out.printf("Result = %d%n", r.get());
		pool.shutdown();
	}
}


