using static MagicPlace_Utility.DS;

namespace MagicPlace_Web.Models
{
    public class APIRequest
    {
        public APITipo APITipo { get; set; } = APITipo.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
