import java.util.*;

class StreamTest2{
	
	static class Journey{
		
		private float dist = 500;
		private Interval dur;

		Journey(Interval val){
			dur = val;
		}

		public Interval duration(){
			return dur;
		}

		public double speed(){
			return 3.6 * dist / dur.time();
		}
	}

	public static void main(String[] args){
		int l = args.length > 0 ? Integer.parseInt(args[0]) : 0;
		List<Interval> store = new ArrayList<>();
		store.add(new Interval(4, 31));
		store.add(new Interval(7, 12));
		store.add(new Interval(5, 23));
		store.add(new Interval(6, 54));
		store.add(new Interval(3, 45));
		store.add(new Interval(2, 36));
		store.stream()
			 .filter(i -> i.time() > l)
			 .sorted()
			 .map(Journey::new) //.map(i -> new Journey(i))
			 .forEach(j -> System.out.printf("%s\t%.1f%n", j.duration(), j.speed()));
		Interval sum = store.stream().filter(i -> i.time() > l).reduce(new Interval(0, 0), Interval::add);
		System.out.printf("Total Interval = %s%n", sum);
	}
}


