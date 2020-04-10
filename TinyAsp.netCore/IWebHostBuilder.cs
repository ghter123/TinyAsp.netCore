using System;

namespace TinyAsp.netCore
{
    public interface IWebHostBuilder
    {
        IWebHostBuilder UseServer(IServer service);
        IWebHostBuilder Configure(Action<IApplicationBuilder> configure);
        IWebHost Build();
    }
}
