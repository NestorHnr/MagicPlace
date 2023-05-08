using AutoMapper;
using MagicPlace_Web.Dto;
using MagicPlace_Web.Models;
using MagicPlace_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace MagicPlace_Web.Controllers
{
    public class PlaceController : Controller
    {

        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlaceController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexPlace()
        {
            List<PlaceDto> placeList = new();

            var response = await _placeService.GetAll<APIResponse>();

            if (response != null && response.IsExitoso) {
                placeList = JsonConvert.DeserializeObject<List<PlaceDto>>(Convert.ToString(response.Result));

            }
            return View(placeList);
        }

        //Get
        public async Task<IActionResult> CreatePlace()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreatePlace(PlaceCreateDto modelo)
        {
            if (ModelState.IsValid) 
            {
                var response = await _placeService.Create<APIResponse>(modelo);

                if (response != null && response.IsExitoso) {

                    TempData["Exitoso"] = "Place created successfully";
                    return RedirectToAction(nameof(IndexPlace));
                }
            }
            return View(modelo);
        }

        public async Task<IActionResult> UpdatePlace(int placeId) 
        {
            var response = await _placeService.GetById<APIResponse>(placeId);

            if (response != null && response.IsExitoso)
            {
                PlaceDto model = JsonConvert.DeserializeObject<PlaceDto>(Convert.ToString(response.Result));
                return View(_mapper.Map<PlaceUpdateDto>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdatePlace(PlaceUpdateDto modelo)
        {
            if (ModelState.IsValid)
            { 
                var response = await _placeService.Update<APIResponse>(modelo);

                if (response != null && response.IsExitoso)
                {
                    TempData["Exitoso"] = "Place update successfully";
                    return RedirectToAction(nameof(IndexPlace));
                }
            }
            return View(modelo);
        }


        public async Task<IActionResult> DeletePlace(int placeId)
        {
            var response = await _placeService.GetById<APIResponse>(placeId);

            if (response != null && response.IsExitoso)
            {
                PlaceDto model = JsonConvert.DeserializeObject<PlaceDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeletePlace(PlaceDto modelo)
        {
            var response = await _placeService.Delete<APIResponse>(modelo.Id);

            if (response != null && response.IsExitoso)
            {
                TempData["Exitoso"] = "Place delete successfully";
                return RedirectToAction(nameof(IndexPlace));
            }
            TempData["Error"] = "An error occurred while deleting";
            return View(modelo);
        }
    }
}
