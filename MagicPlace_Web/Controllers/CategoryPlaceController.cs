using AutoMapper;
using MagicPlace_Web.Dto;
using MagicPlace_Web.Models;
using MagicPlace_Web.Models.ViewModel;
using MagicPlace_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MagicPlace_Web.Controllers
{
    public class CategoryPlaceController : Controller
    {
        private readonly ICategoryPlaceService _categoryPlaceService;
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public CategoryPlaceController(ICategoryPlaceService categoryPlaceService,
                                       IPlaceService placeService,
                                       IMapper mapper)
        {
            _categoryPlaceService = categoryPlaceService;
            _placeService = placeService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexCategoryPlace()
        {
            List<CategoryPlaceDto> categoryPlaceList = new();

            var response = await _categoryPlaceService.GetAll<APIResponse>();

            if (response != null && response.IsExitoso)
            {
                categoryPlaceList = JsonConvert.DeserializeObject<List<CategoryPlaceDto>>(Convert.ToString(response.Result));
            }

            return View(categoryPlaceList);
        }

        public async Task<IActionResult> CreateCategoryPlace()
        {
            CategoryPlaceViewModel categoryPlaceVM = new();

            var response = await _placeService.GetAll<APIResponse>();

            if (response != null && response.IsExitoso)
            {
                categoryPlaceVM.ListPlace = JsonConvert.DeserializeObject<List<PlaceDto>>(Convert.ToString(response.Result))
                                            .Select(p => new SelectListItem
                                            {
                                                Text = p.Name,
                                                Value = p.Id.ToString()
                                            });
            }
            return View(categoryPlaceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateCategoryPlace(CategoryPlaceViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryPlaceService.Create<APIResponse>(modelo.CategoryPlace);
                if (response != null && response.IsExitoso)
                {
                    TempData["Exitoso"] = "Category place created successfully";
                    return RedirectToAction(nameof(IndexCategoryPlace));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessage", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var res = await _placeService.GetAll<APIResponse>();

            if (res != null && res.IsExitoso)
            {
                modelo.ListPlace = JsonConvert.DeserializeObject<List<PlaceDto>>(Convert.ToString(res.Result))
                                            .Select(p => new SelectListItem
                                            {
                                                Text = p.Name,
                                                Value = p.Id.ToString()
                                            });
            }
            return View(modelo);
        }

        public async Task<IActionResult> UpdateCategoryPlace(int NuCategory)
        {
            CategoryPlaceUpdateViewModel categoryPlaceVM = new();

            var response = await _categoryPlaceService.GetById<APIResponse>(NuCategory);
            if (response != null && response.IsExitoso)
            {
                CategoryPlaceDto modelo = JsonConvert.DeserializeObject<CategoryPlaceDto>(Convert.ToString(response.Result));
                categoryPlaceVM.CategoryPlace = _mapper.Map<CategoryUpdatePlaceDto>(modelo);
            }

            response = await _placeService.GetAll<APIResponse>();

            if (response != null && response.IsExitoso)
            {
                categoryPlaceVM.ListPlace = JsonConvert.DeserializeObject<List<PlaceDto>>(Convert.ToString(response.Result))
                                            .Select(p => new SelectListItem
                                            {
                                                Text = p.Name,
                                                Value = p.Id.ToString()
                                            });
                return View(categoryPlaceVM);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateCategoryPlace(CategoryPlaceUpdateViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryPlaceService.Update<APIResponse>(modelo.CategoryPlace);
                if (response != null && response.IsExitoso)
                {
                    TempData["Exitoso"] = "Category place update successfully";
                    return RedirectToAction(nameof(IndexCategoryPlace));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessage", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var res = await _placeService.GetAll<APIResponse>();

            if (res != null && res.IsExitoso)
            {
                modelo.ListPlace = JsonConvert.DeserializeObject<List<PlaceDto>>(Convert.ToString(res.Result))
                                            .Select(p => new SelectListItem
                                            {
                                                Text = p.Name,
                                                Value = p.Id.ToString()
                                            });
            }
            return View(modelo);
        }


        public async Task<IActionResult> DeleteCategoryPlace(int NuCategory)
        {
            CategoryPlaceDeleteViewModel categoryPlaceVM = new();

            var response = await _categoryPlaceService.GetById<APIResponse>(NuCategory);
            if (response != null && response.IsExitoso)
            {
                CategoryPlaceDto modelo = JsonConvert.DeserializeObject<CategoryPlaceDto>(Convert.ToString(response.Result));
                categoryPlaceVM.CategoryPlace = modelo;
            }

            response = await _placeService.GetAll<APIResponse>();

            if (response != null && response.IsExitoso)
            {
                categoryPlaceVM.ListPlace = JsonConvert.DeserializeObject<List<PlaceDto>>(Convert.ToString(response.Result))
                                            .Select(p => new SelectListItem
                                            {
                                                Text = p.Name,
                                                Value = p.Id.ToString()
                                            });
                return View(categoryPlaceVM);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteCategoryPlace(CategoryPlaceDeleteViewModel modelo) 
        {
            var response = await _categoryPlaceService.Delete<APIResponse>(modelo.CategoryPlace.NuCategory);
            if (response != null && response.IsExitoso) 
            {
                TempData["Exitoso"] = "Category place Delete successfully";
                return RedirectToAction(nameof(IndexCategoryPlace));
            }

            TempData["Error"] = "An error occurred while deleting";
            return View(modelo);
        }
    }
}
