using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace TinyAsp.netCore
{
    public class HttpListenerFeature : IHttpFeature
    {
        private readonly HttpListenerContext _httpListenerContext;

        public Stream ResponeseBody => _httpListenerContext.Response.OutputStream;
        public Stream RequestBody => _httpListenerContext.Request.InputStream;
        public Uri Url => _httpListenerContext.Request.Url;
        public int StatusCode => _httpListenerContext.Response.StatusCode;
        public NameValueCollection ResponeseHeaders => _httpListenerContext.Response.Headers;
        public NameValueCollection RequestHeaders => _httpListenerContext.Request.Headers;

        public HttpListenerFeature(HttpListenerContext httpListenerFeature)
        {
            _httpListenerContext = httpListenerFeature;
        }
    }
}
