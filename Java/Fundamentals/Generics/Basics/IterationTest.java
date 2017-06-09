import java.util.Iterator;

class IterationTest{

	static class SimpleStack<V> implements Iterable<V>{
		
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

		public Iterator<V> iterator(){
			return new Iterator<V>(){
				
				private Node current = top;

				public boolean hasNext(){
					return current != null;
				}

				public V next(){
					V result = current.value;
					current = current.below;
					return result;
				}
			};
		}
	}

	public static void main(String[] args){
		int[] array = {12, 23, 34, 45, 56, 67, 78, 89};
		System.out.println("All integers in array");
		for(int n : array)
			System.out.println(n);
		SimpleStack<Interval> stack = new SimpleStack<>();
		stack.push(new Interval(4, 31));
		stack.push(new Interval(7, 12));
		stack.push(new Interval(5, 23));
		stack.push(new Interval(6, 54));
		stack.push(new Interval(3, 45));
		System.out.println("All Intervals on stack");
		for(Interval i : stack)
			System.out.println(i);
	}
}


