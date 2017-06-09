import java.util.*;

class LinkedListTest{
	
	public static void main(String[] args){
		List<Interval> store = new LinkedList<>();
		store.add(new Interval(4, 31));
		store.add(new Interval(7, 12));
		store.add(new Interval(5, 23));
		store.add(new Interval(6, 54));
		store.add(new Interval(3, 45));
		store.add(new Interval(2, 151));
		for(Interval i : store)
			System.out.println(i);
		System.out.printf("Third Interval = %s%n", store.get(2));
	}
}


