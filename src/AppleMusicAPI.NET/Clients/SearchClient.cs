using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class SearchClient : BaseClient
    {
        public SearchClient(HttpClient httpClient, IJsonSerializer jsonSerializer) 
            : base(httpClient, jsonSerializer)
        {
        }
    }
}
