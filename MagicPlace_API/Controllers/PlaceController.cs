using Microsoft.AspNetCore.Mvc;

namespace MagicPlace_API.Controllers
{
    public class PlaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
