using System;
using System.Collections.Specialized;
using System.IO;

namespace TinyAsp.netCore
{
    public interface IHttpFeature
    {
        Stream ResponeseBody { get; }
        int StatusCode { get; }
        NameValueCollection ResponeseHeaders { get; }
        Uri Url { get; }
        NameValueCollection RequestHeaders { get; }
        Stream RequestBody { get; }
    }
}
