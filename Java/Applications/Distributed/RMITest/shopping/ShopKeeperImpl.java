package shopping;

import java.rmi.*;

public class ShopKeeperImpl extends java.rmi.server.UnicastRemoteObject implements ShopKeeper{

	public ShopKeeperImpl() throws RemoteException{
		super(); //exports this object
	}

	public ItemInfo getItemInfo(String name) throws RemoteException{
		int id = Store.find(name);
		if(id >= 0){
			ItemInfo info = new ItemInfo();
			info.unitPrice = 1.06 * Store.priceOf(id);
			info.currentStock = Store.stockOf(id);
			return info;
		}
		return null;
	}

	public float getBulkDiscount(int quantity) throws RemoteException{
		return quantity < 6 ? 0 : 5;
	}
}

