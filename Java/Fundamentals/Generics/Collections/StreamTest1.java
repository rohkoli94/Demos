import java.util.stream.*;

class StreamTest1{

	public static void main(String[] args){
		int[] digits = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
		/*
		for(int n : digits){
			if((n % 2) == 1)
				System.out.println(n * n);
		}
		*/
		IntStream.of(digits).filter(n -> (n % 2) == 1).map(n -> n * n).forEach(System.out::println);
	}
}


