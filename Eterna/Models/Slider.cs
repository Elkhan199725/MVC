using System.ComponentModel.DataAnnotations;

namespace Eterna.Models;

public class Slider : BaseClass
{
    [Required(ErrorMessage ="The Title 1 field is required!")]
    [StringLength(maximumLength:25)]
    public string Title1 { get; set; }
    [Required]
    [StringLength(maximumLength:25)]
    public string? Title2 { get; set; }
    [Required]
    [StringLength(maximumLength:150)]
    public string? Description{ get; set; }
    public string? ImageUrl { get; set; }
    public string? RedirectUrl { get; set; }
}
