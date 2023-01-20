namespace MyWebApiApp.Models
{
    public class ItemVM
    {
        public string? Name { get; set; }
        public double UnitPrice { get; set; }
    }
    public class Item : ItemVM
    {
        public Guid Id { get; set; }
    }
    public class ItemModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double UnitPrice { get; set; }
        public string? Category { get; set; }
    }
}
