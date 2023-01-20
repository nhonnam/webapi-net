namespace MyWebApiApp.Data
{
    public enum OrderSatus
    {
        New = 0, Paid = 1, Completed = 2, Canceled = -1
    }
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderSatus Status { get; set; }
        public string? Customer { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
    }
}
