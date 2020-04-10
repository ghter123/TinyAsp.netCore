using System;
using System.Threading.Tasks;

namespace TinyAsp.netCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await new WebHostBuilder()
                    .UseHttpListener()
                    .Configure(app => app
                        .Use(FirstMiddleware)
                        .Use(SecondMiddleware)
                        .Use(ThirdMiddleware))
                    .Build()
                    .StartAsync();
            });
            Console.ReadKey();
        }

        public static Func<HttpContext, Task> FirstMiddleware(Func<HttpContext, Task> next)
        => async context =>
        {
            await context.HttpResponse.WriteAsync("First=>");
            await next(context);
        };

        public static Func<HttpContext, Task> SecondMiddleware(Func<HttpContext, Task> next)
        => async context =>
        {
            await context.HttpResponse.WriteAsync("Second=>");
            await next(context);
        };

        public static Func<HttpContext, Task> ThirdMiddleware(Func<HttpContext, Task> next)
        => async context =>
        {
            await context.HttpResponse.WriteAsync("Third");
        };
    }
}
