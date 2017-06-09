package shopping;

import java.rmi.*;

public class CartImpl extends java.rmi.server.UnicastRemoteObject implements Cart{

	private double payment;

	public CartImpl() throws RemoteException{}

	public void addItem(String name) throws MissingItemException, RemoteException{
		int id = Store.find(name);
		if(id < 0)
			throw new MissingItemException(name);
		payment += 1.06 * Store.priceOf(id);
	}

	public double checkout() throws RemoteException{
		unexportObject(this, false);
		return payment;
	}
}

