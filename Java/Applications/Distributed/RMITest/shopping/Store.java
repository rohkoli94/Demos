package shopping;

import java.util.*;

class Store{

	public static int find(String item){
		String[] items = {"apple", "mango", "orange", "peach", "pear"};
		return Arrays.binarySearch(items, item);
	}

	public static double priceOf(int id){
		double[] prices = {20.75, 25.50, 9.25, 4.50, 5.75};
		return prices[id];
	}

	public static int stockOf(int id){
		int[] stocks = {100, 200, 300, 250, 150};
		return stocks[id];
	}
}

