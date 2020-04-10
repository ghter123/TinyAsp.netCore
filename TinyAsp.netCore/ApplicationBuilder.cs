using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TinyAsp.netCore
{
    public class ApplicationBuilder : IApplicationBuilder
    {
        private readonly List<Func<Func<HttpContext, Task>, Func<HttpContext, Task>>> _midderwares = new List<Func<Func<HttpContext, Task>, Func<HttpContext, Task>>>();
        public Func<HttpContext, Task> Builder()
        {
            _midderwares.Reverse();
            return httpContext =>
            {
                Func<HttpContext, Task> next = _ =>
                {
                    _.HttpResponse.StatusCode = 404;
                    return Task.CompletedTask;
                };

                _midderwares.ForEach(midderware =>
                {
                    next = midderware(next);
                });

                return next(httpContext);
            };
        }

        public IApplicationBuilder Use(Func<Func<HttpContext, Task>, Func<HttpContext, Task>> midderware)
        {
            _midderwares.Add(midderware);
            return this;
        }
    }
}
