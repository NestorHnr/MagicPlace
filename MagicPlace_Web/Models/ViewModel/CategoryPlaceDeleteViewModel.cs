using MagicPlace_Web.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicPlace_Web.Models.ViewModel
{
    public class CategoryPlaceDeleteViewModel
    {
        public CategoryPlaceDeleteViewModel()
        {
            CategoryPlace = new CategoryPlaceDto(); 
        }

        public CategoryPlaceDto CategoryPlace { get; set; }

        public IEnumerable<SelectListItem> ListPlace { get; set; }

    }
}
