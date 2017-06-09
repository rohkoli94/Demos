import java.util.stream.*;

class ParallelStreamTest{

	private static long processValue(int value){
		System.out.printf("Worker<%x> is processing value %d%n", Thread.currentThread().hashCode(), value);
		Worker.doWork(value);
		return value * value;
	}

	public static void main(String[] args) throws Exception{
		long r = IntStream.range(1, 21)
						  .parallel()
						  .mapToLong(ParallelStreamTest::processValue)
						  .sum();
		System.out.printf("Result = %d%n", r);
	}
}

