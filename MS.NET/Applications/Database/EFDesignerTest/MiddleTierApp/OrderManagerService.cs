using System;

namespace MiddleTierApp
{
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OrderManagerService : Sales.IOrderManager
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public int PlaceOrder(string customerId, int productNo, int quantity)
        {
            using (ShopEntities shop = new ShopEntities())
            {
                Counter ctr = shop.Counters.Find("order");
                OrderDetail entry = new OrderDetail
                {
                    OrderNo = ++ctr.CurrentValue + 1000,
                    OrderDate = DateTime.Today,
                    CustomerId = customerId,
                    ProductNo = productNo,
                    Quantity = quantity
                };

                shop.OrderDetails.Add(entry);
                shop.SaveChanges();

                return entry.OrderNo;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public decimal SellProduct(int productNo, int quantity)
        {
            using (ShopEntities shop = new ShopEntities())
            {
                Product product = shop.Products.Find(productNo);
                product.Stock -= quantity;
                shop.SaveChanges();

                return quantity * product.Price;
            }
        }
    }
}
