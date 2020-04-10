using System;
using System.Threading.Tasks;

namespace TinyAsp.netCore
{
    public interface IServer
    {
        Task StartAsync(Func<HttpContext, Task> handle);
    }
}
