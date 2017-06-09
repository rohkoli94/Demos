class WildCardTest{

	interface Stack<V>{
		
		void push(V value);

		V pop();

		boolean empty();
	}
	
	static class SimpleStack<V> implements Stack<V>{
		
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

		public void copy(Stack<? super V> target){
			for(Node n = top; n != null; n = n.below)
				target.push(n.value);
		}
	}

	static class FiniteStack<V> implements Stack<V>{
		
		private int count;
		private V[] values;

		FiniteStack(V[] store){
			values = store;
		}

		public void push(V value){
			values[count++] = value;
		}

		public V pop(){
			return values[--count];
		}

		public boolean empty(){
			return count == 0;
		}
	}

	private static void printStack(Stack<?> stack){
		for(int i = 0; !stack.empty(); ++i){
			if(i > 0) System.out.print(", ");
			System.out.print(stack.pop());
		}
		System.out.println();
		//stack.push("Sunday");
	}

	public static void main(String[] args){
		SimpleStack<String> a = new SimpleStack<String>();
		a.push("Monday");
		a.push("Tuesday");
		a.push("Wednesday");
		a.push("Thursday");
		a.push("Friday");
		FiniteStack<String> b = new FiniteStack<>(new String[12]);
		b.push("June");
		b.push("May");
		b.push("April");
		b.push("March");
		a.copy(b);
		SimpleStack<Interval> c = new SimpleStack<>();
		c.push(new Interval(4, 31));
		c.push(new Interval(7, 12));
		c.push(new Interval(5, 23));
		c.push(new Interval(6, 54));
		c.push(new Interval(3, 45));
		SimpleStack<Object> d = new SimpleStack<>();
		d.push(23.4);
		d.push("Saturday");
		d.push(new Interval(8, 20));
		c.copy(d);
		printStack(a);
		printStack(b);
		printStack(c);
		printStack(d);
	}
}


