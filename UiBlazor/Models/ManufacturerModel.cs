using System.ComponentModel.DataAnnotations;

namespace UiBlazor.Models
{
    public class Manufacturer
    {
        [Required]
        public int? ManufacturerId { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
