using System.ComponentModel.DataAnnotations;

namespace MagicPlace_Web.Dto
{
    public class PlaceCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Detail { get; set; }

        [Required]
        public double Cost { get; set; }

        public int Ocupants { get; set; }

        public int SquareMeters { get; set; }

        public string ImageUrl { get; set; }

        public string Service { get; set; }
    }
}
