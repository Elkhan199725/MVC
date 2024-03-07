using System.ComponentModel.DataAnnotations;

namespace Eterna.Models;

public class Feature : BaseClass
{
    [Required]
    [StringLength(50)]
    public string? Title { get; set; }
    [Required]
    [StringLength(250)]
    public string? Description { get; set; }
    public string? RedirectUrl { get; set; }
    public string? IconClass { get; set; }
}
