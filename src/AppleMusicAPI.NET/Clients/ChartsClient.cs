using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Resources;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class ChartsClient : BaseClient
    {
        private const string BaseRequestUri = "catalog";

        public ChartsClient(HttpClient httpClient, IJsonSerializer jsonSerializer) 
            : base(httpClient, jsonSerializer)
        {
        }

        //public async Task<List<Storefront>> GetStorefronts(string storefront, )
        //{
        //    var responseRoot = await Get($"{BaseRequestUri}/{storefront}/charts", new Dictionary<string, string> { { "ids", string.Join(',', ids) } });

        //    return responseRoot.Data
        //        .Cast<Storefront>()
        //        .ToList();
        //}
    }
}
