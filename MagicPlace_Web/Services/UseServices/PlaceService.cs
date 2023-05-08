using MagicPlace_Utility;
using MagicPlace_Web.Dto;
using MagicPlace_Web.Models;
using MagicPlace_Web.Services.IServices;

namespace MagicPlace_Web.Services.UseServices
{
    public class PlaceService : BaseService, IPlaceService
    {
        public readonly IHttpClientFactory HttpClient;
        public string _PlaceUrl;

        public PlaceService(IHttpClientFactory httpClient, IConfiguration config) : base(httpClient)
        {
            HttpClient = httpClient;

            _PlaceUrl = config.GetValue<string>("ServiceUrls:API_URL");

        }
        public Task<T> Create<T>(PlaceCreateDto dto)
        {
            return SendAsync<T>(new APIRequest() 
            {
                APITipo = DS.APITipo.POST,
                Data = dto,
                Url = _PlaceUrl+"/api/Place"
            });
        }

        public Task<T> Delete<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.DELETE,
                Url = _PlaceUrl + "/api/Place/" + id
            });
        }

        public Task<T> GetAll<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _PlaceUrl + "/api/Place"
            });
        }

        public Task<T> GetById<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _PlaceUrl + "/api/Place/" + id
            });
        }

        public Task<T> Update<T>(PlaceUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.PUT,
                Data = dto,
                Url = _PlaceUrl + "/api/Place/"+ dto.Id
            });
        }
    }
}
