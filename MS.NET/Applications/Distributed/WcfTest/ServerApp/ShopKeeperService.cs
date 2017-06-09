namespace ServerApp
{
    using Shopping;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ShopKeeperService : IShopKeeper
    {
        public float GetBulkDiscount(int quantity)
        {
            return quantity < 6 ? 0 : 5;              
        }

        public ItemInfo GetItemInfo(string name)
        {
            int id = Store.Find(name);

            if(id >= 0)
            {
                ItemInfo info = new ItemInfo();
                info.UnitPrice = 1.06 * Store.PriceOf(id);
                info.CurrentStock = Store.StockOf(id);
                return info;
            }

            return null;
        }
    }
}
