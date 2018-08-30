using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
#pragma warning disable IDE1006 // Naming Styles
    public class iCloudMusicLibraryClient : BaseClient
#pragma warning restore IDE1006 // Naming Styles
    {
        public iCloudMusicLibraryClient(HttpClient httpClient, IJsonSerializer jsonSerializer) 
            : base(httpClient, jsonSerializer)
        {
        }
    }
}
