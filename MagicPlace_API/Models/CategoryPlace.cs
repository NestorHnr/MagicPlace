using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicPlace_API.Models
{
    public class CategoryPlace
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NuCategory { set; get; }

        [Required]
        public int PlaceId { set; get; }

        [ForeignKey("PlaceId")]
        public Place Place { set; get; }

        public string SpecialDetails { set; get; }

        public int Cost { set; get; }

        public DateTime CreateTime { set; get; }

        public DateTime UpdateTime { set; get; }
    }
}
