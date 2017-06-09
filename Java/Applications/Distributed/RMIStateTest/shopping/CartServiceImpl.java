package shopping;

import java.rmi.*;

public class CartServiceImpl extends java.rmi.server.UnicastRemoteObject implements CartService{

	public CartServiceImpl() throws RemoteException{}

	public Cart create() throws RemoteException{
		return new CartImpl();
	}
}

