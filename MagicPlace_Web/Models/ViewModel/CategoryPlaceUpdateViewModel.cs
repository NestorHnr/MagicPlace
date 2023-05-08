using MagicPlace_Web.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicPlace_Web.Models.ViewModel
{
    public class CategoryPlaceUpdateViewModel
    {
        public CategoryPlaceUpdateViewModel()
        {
            CategoryPlace = new CategoryUpdatePlaceDto(); 
        }

        public CategoryUpdatePlaceDto CategoryPlace { get; set; }

        public IEnumerable<SelectListItem> ListPlace { get; set; }

    }
}
