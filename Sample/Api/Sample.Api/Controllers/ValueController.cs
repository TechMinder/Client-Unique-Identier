using Microsoft.AspNetCore.Mvc;
using SampleApi.Client;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private SampleApiClient _client;
        public ValueController(SampleApiClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var headers =  Request.Headers.Select(a=> a.Key + ":" + a.Value).ToArray();
            
            return Ok($"Successful \r\n Headers: {string.Join(",",headers)}");
        }

        [HttpPost]
        public async Task<IActionResult> Post(string data)
        {
            var response = _client.Get();
            var headers = Request.Headers.Select(a => a.Key + ":" + a.Value).ToArray();
            return Ok($"{data} posted.\r\n Headers:{string.Join(",", headers)}");
        }
    }
}
