using System.ComponentModel.DataAnnotations;

namespace RealEstateAPI.Models
{
    public class BrandDto
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 99999999)]
        public int Price { get; set; }
    }
}
