using System.ComponentModel.DataAnnotations;

namespace Eterna.Models;

public class Category : BaseClass
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    public List<Product>? Products { get; set; }
}
