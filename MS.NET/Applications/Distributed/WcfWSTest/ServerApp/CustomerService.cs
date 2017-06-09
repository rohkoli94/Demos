using System;

namespace ServerApp
{
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Runtime.Serialization;

    [DataContract(Name = "Receipt")]
    public class OrderInfo
    {
        [DataMember(Name = "Status")]
        public int Code { get; set; }
        
        [DataMember(Name = "Payment")]
        public double Amount { get; set; }  
    }

    [ServiceContract(Name = "CustomerSupport")]
    public class CustomerService
    {
        [OperationContract(Name = "Inquire")]
        [WebGet(UriTemplate = "ajax/{item}")]
        public int GetStock(string item)
        {
            int id = Store.Find(item);

            return id < 0 ? 0 : Store.StockOf(id);
        }

        [OperationContract(Name = "Purchase")]
        [WebInvoke(UriTemplate = "ajax", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public OrderInfo ProcessOrder(string item, int quantity)
        {
            OrderInfo info = new OrderInfo();
            int id = Store.Find(item);

            if(id >= 0 && quantity <= Store.StockOf(id))
            {
                info.Code = 1000 + Environment.TickCount % 1000000;
                info.Amount = 1.06 * quantity * Store.PriceOf(id) * (quantity < 6 ? 1 : 0.95);
            }

            return info;
        }
    }
}