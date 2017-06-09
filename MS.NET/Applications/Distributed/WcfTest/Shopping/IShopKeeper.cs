namespace Shopping
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IShopKeeper
    {
        [OperationContract]
        ItemInfo GetItemInfo(string name);

        [OperationContract]
        float GetBulkDiscount(int quantity);
    }
}
