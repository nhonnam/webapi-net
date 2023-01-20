namespace MyWebApiApp.Data
{
    public class OrderDetails
    {
        public Guid ItemId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public byte Discount { get; set; }
        //relationship
        public Order? Order { get; set; }
        public Item? Item { get; set; }
    }
}
