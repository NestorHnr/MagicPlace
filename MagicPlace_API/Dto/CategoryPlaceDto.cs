using MagicPlace_API.Models;
using System.ComponentModel.DataAnnotations;

namespace MagicPlace_API.Dto
{
    public class CategoryPlaceDto
    {
        public int NuCategory { set; get; }

        [Required]
        public int PlaceId { set; get; }

        public string SpecialDetails { set; get; }

        public int Cost { set; get; }

        public PlaceDto Place { set; get; }

    }
}
