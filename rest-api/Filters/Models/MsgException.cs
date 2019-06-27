using System.Net;


namespace rest_api.Filters.Models
{
    public class MsgException
    {
        public HttpStatusCode status { get; set; }
        public string type { get; set; }
        public string message { get; set; } = "";
        public int code { get; set; }
    }
}
