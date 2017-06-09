import java.util.*;

class TreeMapTest{
	
	public static void main(String[] args){
		Map<String, Interval> store = new TreeMap<>();
		store.put("monday", new Interval(4, 31));
		store.put("tuesday", new Interval(7, 12));
		store.put("wednesday", new Interval(5, 23));
		store.put("thursday", new Interval(6, 54));
		store.put("friday", new Interval(3, 45));
		store.put("monday", new Interval(2, 51));
		for(Map.Entry<String, Interval> e : store.entrySet())
			System.out.printf("%s = %s%n", e.getKey(), e.getValue());
		Scanner input = new Scanner(System.in);
		System.out.print("Key: ");
		String key = input.next();
		Interval val = store.get(key);
		if(val == null)
			System.out.println("No such key!");
		else
			System.out.printf("Value = %s%n", val);
	}
}


