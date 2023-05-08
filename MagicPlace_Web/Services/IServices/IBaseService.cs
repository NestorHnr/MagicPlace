using MagicPlace_Web.Models;

namespace MagicPlace_Web.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse responseModel { get; set; }

        Task<T> SendAsync <T>(APIRequest apiRequest);
    }
}
