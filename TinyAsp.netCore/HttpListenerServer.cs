using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TinyAsp.netCore
{
    public class HttpListenerServer : IServer
    {
        private readonly HttpListener _httpListener;
        private readonly string[] _urls;

        public HttpListenerServer(params string[] urls)
        {
            _httpListener = new HttpListener();
            _urls = urls.Any() ? urls : new string[] { "http://localhost:5000/" };
        }

        public async Task StartAsync(Func<HttpContext, Task> handle)
        {
            Array.ForEach(_urls, o =>
            {
                _httpListener.Prefixes.Add(o);
            });
            _httpListener.Start();

            while (true)
            {
                var listenerContext = await _httpListener.GetContextAsync();
                var feature = new HttpListenerFeature(listenerContext);
                var httpContext = new HttpContext(feature);
                await handle(httpContext);
                listenerContext.Response.Close();
            }
        }
    }
}
