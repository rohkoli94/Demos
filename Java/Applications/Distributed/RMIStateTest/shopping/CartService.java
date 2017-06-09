package shopping;

import java.rmi.*;

public interface CartService extends Remote{

	Cart create() throws RemoteException;

}

