using System.Collections.Generic;

namespace SampleApi.Client
{
    public interface IHttpHeader
    {
        Dictionary<string, string> CurrentRequestHeaders { get; set; }
    }
}