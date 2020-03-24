using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApi.Client
{
    public class HttpHeader : IHttpHeader
    {
        public Dictionary<string, string> CurrentRequestHeaders { get; set; } = new Dictionary<string, string>();

    }
}
