import java.util.*;

class ArrayListTest{
	
	public static void main(String[] args){
		List<Interval> store = new ArrayList<>();
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


