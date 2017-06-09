package finance;

public class HomeLoan implements LoanPolicy{

	public float interestRate(double p, int n){
		return (n <= 5) ? 9.5f : 10.0f;
	}
}












