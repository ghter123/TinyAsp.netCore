using System;
using System.Collections.Specialized;
using System.IO;

namespace TinyAsp.netCore
{
    public class HttpRequest
    {
        public Uri Url { get; set; }
        public NameValueCollection Headers { get; set; }
        public Stream Body { get; set; }
        
        public HttpRequest(IHttpFeature httpFeature)
        {
            Url = httpFeature.Url;
            Headers = httpFeature.RequestHeaders;
            Body = httpFeature.RequestBody;
        }
    }
}
