using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class RecentHistoryClient : BaseClient
    {
        public RecentHistoryClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }
    }
}
