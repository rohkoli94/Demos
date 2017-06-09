import java.util.*;
import java.util.concurrent.*;

class ExecutorTest1{

	static class Translator implements Callable<String>{

		private String source;
		private int level;

		Translator(String source, int level){
			this.source = source;
			this.level = level;
		}

		public String call(){
			Worker.doWork(level);
			return source.toUpperCase();
		}
	}

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		ExecutorService pool = Executors.newFixedThreadPool(2);
		System.out.print("Part(1/2): ");
		String w1 = input.next();
		Translator t1 = new Translator(w1, 90);
		//String r1 = t1.call();
		Future<String> r1 = pool.submit(t1);
		System.out.print("Part(2/2): ");
		String w2 = input.next();
		Translator t2 = new Translator(w2, 60);
		//String r2 = t2.call();
		Future<String> r2 = pool.submit(t2);
		//String r = r1 + " AND " + r2;
		String r = r1.get() + " AND " + r2.get();
		System.out.printf("Result = %s%n", r);
		pool.shutdown();
	}
}


