using Flurl.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleApi.Client
{
   public class ClientBase
    {
        private IHttpHeader _header;
        protected string _appName;
        public ClientBase(IHttpHeader header)
        {
            _header = header;            
        }

        protected async Task<HttpResponseMessage> Get(string baseUrl)
        {
            HttpResponseMessage res;
            
            var transactionId = Guid.NewGuid().ToString();
            var correlationID = Guid.NewGuid().ToString();
            if (_header.CurrentRequestHeaders?.Count > 0)
            {
                res = await baseUrl.WithHeaders(_header.CurrentRequestHeaders).GetAsync();

            }
            else
            {
                res = await baseUrl.WithHeaders(new Dictionary<string, string> {{ "X-Request-ID", transactionId },
                                           { "X-Correlation-ID", correlationID },
                                           { "X-Application-ID", _appName }}).GetAsync();

            }
            return res;
        }

    }
}
