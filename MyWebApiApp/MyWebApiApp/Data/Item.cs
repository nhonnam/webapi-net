using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }
        public byte Discount { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Item()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
    }
}
