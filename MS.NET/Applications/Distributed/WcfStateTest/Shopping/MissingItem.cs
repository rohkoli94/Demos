namespace Shopping
{
    using System.Runtime.Serialization;

    [DataContract]
    public class MissingItem
    {
        [DataMember]
        public string ItemName { get; set; }

        [DataMember]
        public bool IsOutOfStock { get; set; }  
    }
}
