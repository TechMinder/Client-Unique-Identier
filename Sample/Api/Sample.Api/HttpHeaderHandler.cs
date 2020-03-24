using Microsoft.AspNetCore.Http;
using SampleApi.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Api
{
    public class HttpHeaderHandler
    {
        /*X-Request-ID, X-Correlation-ID, X-Application-ID*/

       
        private readonly RequestDelegate _next;
        public HttpHeaderHandler(RequestDelegate next)
        {
            _next = next;           
        }


       public async Task Invoke(HttpContext context, IHttpHeader httpHeader)
        {
            var request = context.Request;
            if (request.Headers.ContainsKey("X-Request-ID"))
            {
                httpHeader.CurrentRequestHeaders.Add("X-Request-ID",request.Headers["X-Request-ID"]);
            }
            if (request.Headers.ContainsKey("X-Correlation-ID"))
            {
                httpHeader.CurrentRequestHeaders.Add("X-Correlation-ID", request.Headers["X-Correlation-ID"]);
            }
            if (request.Headers.ContainsKey("X-Application-ID"))
            {
                httpHeader.CurrentRequestHeaders.Add("X-Application-ID", request.Headers["X-Application-ID"]);
            }

             await _next.Invoke(context);
        }
    }
}
