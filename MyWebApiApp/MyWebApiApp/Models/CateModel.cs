using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Models
{
    public class CateModel
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
