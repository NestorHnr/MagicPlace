using System.ComponentModel.DataAnnotations;

namespace MagicPlace_API.Dto
{
    public class PlaceUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public int Ocupants { get; set; }

        [Required]
        public int SquareMeters { get; set; }

        public string ImageUrl { get; set; }

        public string Service { get; set; }
    }
}
