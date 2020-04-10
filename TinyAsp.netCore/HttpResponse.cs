using System.Collections.Specialized;
using System.IO;

namespace TinyAsp.netCore
{
    public class HttpResponse
    {
        public Stream Body { get; set; }
        public int StatusCode { get; set; }
        public NameValueCollection Headers { get; set; }

        public HttpResponse(IHttpFeature httpFeature)
        {
            Body = httpFeature.RequestBody;
            StatusCode = httpFeature.StatusCode;
            Headers = httpFeature.ResponeseHeaders;
        }
    }
}
