using System.ComponentModel.DataAnnotations;

namespace MagicPlace_Web.Dto
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
