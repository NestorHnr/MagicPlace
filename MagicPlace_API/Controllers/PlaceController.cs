using AutoMapper;
using MagicPlace_API.Dto;
using MagicPlace_API.Models;
using MagicPlace_API.Respositories.IRespositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicPlace_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceRepository _placeRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public PlaceController(IPlaceRepository placeRepo, IMapper mapper)
        {
            _placeRepo = placeRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)] //Esto es para documentar los estados

        public async Task<ActionResult<APIResponse>> GetAllPlace()
        {
            try
            {
                IEnumerable<Place> PlaceList = await _placeRepo.GetAll();

                _response.Result = _mapper.Map<IEnumerable<PlaceDto>>(PlaceList);
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


        [HttpGet("{id:int}", Name = "GetByIdPlace")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)] //Esto es para documentar los estados
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetByIdPlace(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                var place = await _placeRepo.GetById(v => v.Id == id);

                if (place == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<PlaceDto>(place);
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
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CreatePlace([FromBody] PlaceCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _placeRepo.GetById(v => v.Name.ToLower() == createDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "La villa con ese nombre ya existe");
                    return BadRequest(ModelState);
                }

                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                Place modelo = _mapper.Map<Place>(createDto);

                modelo.DateCreate = DateTime.Now;
                modelo.DateUpdate = DateTime.Now;
                await _placeRepo.Create(modelo);
                _response.Result = modelo;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetByIdPlace", new { id = modelo.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeletePlace(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var place = await _placeRepo.GetById(v => v.Id == id);

                if (place == null)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _placeRepo.Delete(place);

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
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Esto es para documentar los estados
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePlace(int id, [FromBody] PlaceUpdateDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.Id)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Place modelo = _mapper.Map<Place>(updateDto);

                await _placeRepo.PlaceUpdate(modelo);
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

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Esto es para documentar los estados
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePatcPlace(int id, JsonPatchDocument<PlaceUpdateDto> patchDto)
        {
            try
            {
                if (patchDto == null || id == 0)
                {
                    return BadRequest();
                }
                var place = await _placeRepo.GetById(v => v.Id == id, tracked: false);
                PlaceUpdateDto placeDto = _mapper.Map<PlaceUpdateDto>(place);

                if (place == null) return BadRequest();
                patchDto.ApplyTo(placeDto, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Place modelo = _mapper.Map<Place>(placeDto);
                await _placeRepo.PlaceUpdate(modelo);
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
