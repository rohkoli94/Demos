import java.util.*;

class TreeSetTest{
	
	public static void main(String[] args){
		//Set<Interval> store = new TreeSet<>();
		Set<Interval> store = new TreeSet<>((i, j) -> i.seconds() - j.seconds());
		store.add(new Interval(4, 31));
		store.add(new Interval(7, 12));
		store.add(new Interval(5, 23));
		store.add(new Interval(6, 54));
		store.add(new Interval(3, 45));
		store.add(new Interval(2, 151));
		for(Interval i : store)
			System.out.println(i);
	}
}


