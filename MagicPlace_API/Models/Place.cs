using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicPlace_API.Models
{
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
