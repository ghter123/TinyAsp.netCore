using System;
using System.Threading.Tasks;

namespace TinyAsp.netCore
{
    public interface IApplicationBuilder
    {
        public IApplicationBuilder Use(Func<Func<HttpContext,Task>,Func<HttpContext,Task>> midderwares);
        public Func<HttpContext, Task> Builder();
    }
}
