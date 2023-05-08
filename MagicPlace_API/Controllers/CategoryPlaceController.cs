using AutoMapper;
using MagicPlace_API.Dto;
using MagicPlace_API.Models;
using MagicPlace_API.Respositories.IRespositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicPlace_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryPlaceController : ControllerBase
    {
        private readonly ICategoryPlaceRepository _CategoryRepo;
        private readonly IPlaceRepository _placeRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public CategoryPlaceController(ICategoryPlaceRepository categoryRepo,
                                       IPlaceRepository placeRepo,
                                       IMapper mapper)
        {
            _CategoryRepo = categoryRepo;
            _placeRepo = placeRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] //Esto es para documentar los estados

        public async Task<ActionResult<APIResponse>> GetAllCategoryPlace()
        {
            try
            {
                IEnumerable<CategoryPlace> CategoryList = await _CategoryRepo.GetAll(propertyInclude: "Place");

                _response.Result = _mapper.Map<IEnumerable<CategoryPlaceDto>>(CategoryList);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("{id:int}", Name = "GetByIdCategoryPlace")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Esto es para documentar los estados
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetByIdCategoryPlace(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                var categoryPlace = await _CategoryRepo.GetById(v => v.NuCategory == id, propertyInclude:"Place");

                if (categoryPlace == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<CategoryPlaceDto>(categoryPlace);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CategoryCreatePlace([FromBody] CategoryCreatePlaceDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _CategoryRepo.GetById(v => v.NuCategory == createDto.NuCategory) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Esta categoria ya existe");
                    return BadRequest(ModelState);
                }

                if (await _placeRepo.GetById(v => v.Id == createDto.PlaceId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "El id de este lugar no existe");
                    return BadRequest(ModelState);
                }

                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                CategoryPlace modelo = _mapper.Map<CategoryPlace>(createDto);

                modelo.CreateTime = DateTime.Now;
                modelo.UpdateTime = DateTime.Now;
                await _CategoryRepo.Create(modelo);
                _response.Result = modelo;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetByIdCategoryPlace", new { id = modelo.NuCategory }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteCategoryPlace(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var place = await _CategoryRepo.GetById(v => v.NuCategory == id);

                if (place == null)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _CategoryRepo.Delete(place);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Esto es para documentar los estados
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CategoryUpdate(int id, [FromBody] CategoryUpdatePlaceDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.NuCategory)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (await _placeRepo.GetById(v => v.Id == updateDto.PlaceId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "El id de este lugar no existe");
                    return BadRequest(ModelState);
                }

                CategoryPlace modelo = _mapper.Map<CategoryPlace>(updateDto);

                await _CategoryRepo.CategoryPlaceUpdate(modelo);
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }
    }
}
