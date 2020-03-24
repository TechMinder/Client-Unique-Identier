using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApi.Client
{
    public class Client
    {
        private string _baseUrl;
        private string _appName;

        public Client(string baseUrl,string appName)
        {
            _baseUrl = baseUrl;
            _appName = appName;
        }

        public async Task<string> Get()
        {
            var url = $"{_baseUrl}/value";
            var transactionId = Guid.NewGuid().ToString();
            var correlationID = Guid.NewGuid().ToString();

            var r = await url.WithHeaders(new Dictionary<string, string> {{ "X-Request-ID", transactionId },
                                           { "X-Correlation-ID", correlationID },
                                           { "X-Application-ID", _appName }}).GetAsync();
                        
            return await r.Content.ReadAsStringAsync();
            
        }

        public async Task<string> Post(string value)
        {

            var url = $"{_baseUrl}/value";
            var r = await url.WithHeaders(new Dictionary<string, string> {{ "X-Request-ID", "transactionId" },
                                           { "X-Correlation-ID", "correlationID" },
                                           { "X-Application-ID", _appName }})
                                            .PostJsonAsync(new { data=value }); 
            return await r.Content.ReadAsStringAsync();
        }

       
    }
}
