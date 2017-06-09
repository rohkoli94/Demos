package shopping;

import javax.xml.bind.annotation.*;

@XmlType(name="Receipt")
public class OrderInfo{

	int code;
	double amount;

	@XmlElement(name="Status")
	public final int getCode(){return code;}
	public final void setCode(int value){code = value;}

	@XmlElement(name="Payment")
	public final double getAmount(){return amount;}
	public final void setAmount(double value){amount = value;}
}

