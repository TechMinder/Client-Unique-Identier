using Flurl.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleApi.Client
{
    public class SampleApiClient:ClientBase
    {
        
        private IOptions<ApiConfiguration> _options;         

        public SampleApiClient(IHttpHeader header, IOptions<ApiConfiguration> options)
            :base(header)
        {
            _options = options;
            _appName = _options.Value.AppName;


        }

        public async Task<string> Get()
        {
            HttpResponseMessage res;
            var url = $"{_options.Value.BaseUrl}/value";
           
            res = await Get(url);
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<string> Post(string value)
        {

            var url = $"{_options.Value.BaseUrl}/value";
            url.WithHeaders(new Dictionary<string, string> {{ "X-Request-ID", "transactionId" },
                                           { "X-Correlation-ID", "correlationID" },
                                           { "X-Application-ID", _options.Value.AppName }});
            var r= await $"{_options.Value.BaseUrl}/value".PostJsonAsync(new { data=value }); ;
            return await r.Content.ReadAsStringAsync();
        }

       
    }

    public class ApiConfiguration
    {
        public string BaseUrl { get; set; }
        public string AppName { get; set; }
    }
}
