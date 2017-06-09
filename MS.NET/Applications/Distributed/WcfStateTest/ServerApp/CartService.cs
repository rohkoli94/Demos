namespace ServerApp
{
    using Shopping;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CartService : ICart
    {
        private double payment;

        public void AddItem(string name)
        {
            int id = Store.Find(name);

            if(id < 0)
            {
                MissingItem detail = new MissingItem();
                detail.ItemName = name;
                detail.IsOutOfStock = false;
                throw new FaultException<MissingItem>(detail);
            }

            payment += 1.06 * Store.PriceOf(id);
        }

        public double Checkout()
        {
            return payment;
        }
    }
}
