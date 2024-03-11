using System.ComponentModel.DataAnnotations;

namespace Eterna.Models;

public class Product : BaseClass
{
    public int CategoryId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [Required]
    [StringLength(50)]
    public string? Title { get; set; }
    [StringLength(250)]
    public string? Description { get; set; }
    [StringLength(250)]
    public string? Client { get; set; }
    [StringLength(250)]
    public string? ProjectUrl { get; set; }
    public Category Category { get; set; } = null!;
    public List<ProductImages> ProductImages { get; set; } = null!;
}
