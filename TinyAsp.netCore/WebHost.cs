using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TinyAsp.netCore
{
    public class WebHost : IWebHost
    {
        private readonly IServer _service;
        private readonly Func<HttpContext, Task> _handle;
        public WebHost(IServer service, Func<HttpContext, Task> handle)
        {
            _service = service;
            _handle = handle;
        }
        public async Task StartAsync()
        {
            await _service.StartAsync(_handle);
        }
    }
}
