package basicwebapp;

public class CounterBean implements java.io.Serializable{

	private int step = 1;
	private int current = 0;

	public final int getStep(){return step;}
	public final void setStep(int value){step = value;}

	public synchronized int getNextCount(){
		return current += step;
	}
}

