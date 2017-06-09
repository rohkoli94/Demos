class GenClassTest{

	static class SimpleStack<V>{
		
		class Node{
			
			V value;
			Node below;
			
			Node(V val){
				value = val;
				below = top;
			}
		}

		private Node top;

		public void push(V value){
			top = new Node(value);
		}

		public V pop(){
			V result = top.value;
			top = top.below;
			return result;
		}

		public boolean empty(){
			return top == null;
		}
	}

	public static void main(String[] args){
		SimpleStack<String> a = new SimpleStack<String>();
		a.push("Monday");
		a.push("Tuesday");
		a.push("Wednesday");
		a.push("Thursday");
		a.push("Friday");
		//a.push(12.3);
		SimpleStack<String> b = new SimpleStack<>();
		b.push("June");
		b.push("May");
		b.push("April");
		b.push("March");
		SimpleStack<Interval> c = new SimpleStack<>();
		c.push(new Interval(4, 31));
		c.push(new Interval(7, 12));
		c.push(new Interval(5, 23));
		c.push(new Interval(6, 54));
		c.push(new Interval(3, 45));
		SimpleStack<Double> d = new SimpleStack<>();
		d.push(23.4);
		d.push(34.5);
		d.push(45.6);
		while(!a.empty())
			System.out.println(a.pop());
		System.out.println("-------------------------");
		while(!b.empty())
			System.out.println(b.pop());
		System.out.println("-------------------------");
		while(!c.empty())
			System.out.println(c.pop());
		System.out.println("-------------------------");
		while(!d.empty())
			System.out.println(d.pop());
	}
}


