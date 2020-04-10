namespace TinyAsp.netCore
{
    public class HttpContext
    {
        public HttpRequest HttpRequest { get; set; }
        public HttpResponse HttpResponse { get; set; }

        public HttpContext(IHttpFeature httpFeature)
        {
            HttpRequest = new HttpRequest(httpFeature);
            HttpResponse = new HttpResponse(httpFeature);
        }
    }
}
