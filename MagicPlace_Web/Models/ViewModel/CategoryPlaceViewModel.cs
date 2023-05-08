using MagicPlace_Web.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicPlace_Web.Models.ViewModel
{
    public class CategoryPlaceViewModel
    {
        public CategoryPlaceViewModel()
        {
            CategoryPlace = new CategoryCreatePlaceDto(); 
        }

        public CategoryCreatePlaceDto CategoryPlace { get; set; }

        public IEnumerable<SelectListItem> ListPlace { get; set; }

    }
}
