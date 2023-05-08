using System.ComponentModel.DataAnnotations;

namespace UiBlazor.Models
{
    public class ProducModel
    {
        public int? ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public bool? Disabled { get; set; } = false;
        public string? Image { get; set; }
        [Required]
        public int? ManufactureId { get; set; }
        public ManufacturerModel? Manufacturer { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
