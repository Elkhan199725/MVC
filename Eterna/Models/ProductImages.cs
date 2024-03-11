using System.ComponentModel.DataAnnotations;

namespace Eterna.Models
{
    public class ProductImages : BaseClass
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(250)]
        public string? Url { get; set; }
        public Product? Products { get; set; }
    }
}
