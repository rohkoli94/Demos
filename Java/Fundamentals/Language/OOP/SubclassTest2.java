import payroll.*;

class SubclassTest2{
	
	private static double averageIncome(Employee[] group){
		double total = 0;
		for(Employee member : group){
			total += member.getNetIncome();
		}
		return total / group.length;
	}

	private static double totalSales(Employee[] group){
		double total = 0;
		for(Employee member : group){
			if(member instanceof SalesPerson){
				SalesPerson sp = (SalesPerson)member;
				total += sp.getSales();
			}
		}
		return total;
	}

	public static void main(String[] args){
		Employee[] dept = new Employee[5];
		dept[0] = new Employee(186, 52);
		dept[1] = new Employee(175, 225);
		dept[2] = new SalesPerson(182, 42, 52000);
		dept[3] = new Employee(205, 195);
		dept[4] = new SalesPerson(190, 60, 48000);
		System.out.printf("Average income: %.2f%n", averageIncome(dept));
		System.out.printf("Total sales   : %.2f%n", totalSales(dept));
	}
}

