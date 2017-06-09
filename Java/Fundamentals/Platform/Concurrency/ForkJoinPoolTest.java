import java.util.concurrent.*;

class ForkJoinPoolTest{

	static class Computation extends RecursiveTask<Long>{

		private int low, high;

		Computation(int low, int high){
			this.low = low;
			this.high = high;
		}

		@Override
		public Long compute(){
			if(high - low > 5){
				int mid = (low + high) / 2;
				Computation left = new Computation(low, mid);
				Computation right = new Computation(mid + 1, high);
				right.fork();
				return left.compute() + right.join();
			}
			long result = 0;
			for(int value = low; value <= high; ++value){
				System.out.printf("Worker<%x> is processing value %d%n", Thread.currentThread().hashCode(), value);
				Worker.doWork(value);
				result += value * value;
			}
			return result;
		}
	}

	public static void main(String[] args) throws Exception{
		ForkJoinPool pool = new ForkJoinPool();
		Computation c = new Computation(1, 20);
		long r = pool.invoke(c);
		System.out.printf("Result = %d%n", r);
	}
}


