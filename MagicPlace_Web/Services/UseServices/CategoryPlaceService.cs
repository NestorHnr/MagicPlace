using MagicPlace_Utility;
using MagicPlace_Web.Dto;
using MagicPlace_Web.Models;
using MagicPlace_Web.Services.IServices;

namespace MagicPlace_Web.Services.UseServices
{
    public class CategoryPlaceService : BaseService, ICategoryPlaceService
    {
        public readonly IHttpClientFactory HttpClient;
        public string _PlaceUrl;

        public CategoryPlaceService(IHttpClientFactory httpClient, IConfiguration config) : base(httpClient)
        {
            HttpClient = httpClient;

            _PlaceUrl = config.GetValue<string>("ServiceUrls:API_URL");

        }
        public Task<T> Create<T>(CategoryCreatePlaceDto dto)
        {
            return SendAsync<T>(new APIRequest() 
            {
                APITipo = DS.APITipo.POST,
                Data = dto,
                Url = _PlaceUrl+"/api/CategoryPlace"
            });
        }

        public Task<T> Delete<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.DELETE,
                Url = _PlaceUrl + "/api/CategoryPlace/" + id
            });
        }

        public Task<T> GetAll<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _PlaceUrl + "/api/CategoryPlace"
            });
        }

        public Task<T> GetById<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _PlaceUrl + "/api/CategoryPlace/" + id
            });
        }

        public Task<T> Update<T>(CategoryUpdatePlaceDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.PUT,
                Data = dto,
                Url = _PlaceUrl + "/api/CategoryPlace/"+ dto.NuCategory
            });
        }
    }
}
