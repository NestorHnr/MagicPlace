using System.ComponentModel.DataAnnotations;

namespace MagicPlace_Web.Dto
{
    public class CategoryCreatePlaceDto
    {
        public int NuCategory { set; get; }

        [Required]
        public int PlaceId { set; get; }

        public string SpecialDetails { set; get; }
        public int Cost { set; get; }

    }
}
