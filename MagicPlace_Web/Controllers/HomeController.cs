using AutoMapper;
using MagicPlace_Web.Dto;
using MagicPlace_Web.Models;
using MagicPlace_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MagicPlace_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlaceService _PlaceService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IPlaceService placeService, IMapper mapper)
        {
            _logger = logger;
            _PlaceService = placeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<PlaceDto> placeList = new();

            var response = await _PlaceService.GetAll<APIResponse>();

            if (response != null && response.IsExitoso)
            {
                placeList = JsonConvert.DeserializeObject<List<PlaceDto>>(Convert.ToString(response.Result));
            }

            return View(placeList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}