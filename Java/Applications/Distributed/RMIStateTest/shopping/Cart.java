package shopping;

import java.rmi.*;

public interface Cart extends Remote{

	void addItem(String name) throws MissingItemException, RemoteException;

	double checkout() throws RemoteException;
}

