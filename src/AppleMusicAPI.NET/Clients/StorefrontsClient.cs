using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class StorefrontsClient : BaseClient, IStorefrontsClient
    {
        private const string BaseRequestUri = "storefronts";
        private const string BaseMeRequestUri = "me/storefront";

        public StorefrontsClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        public async Task<StorefrontResponse> GetStorefront(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await Get<StorefrontResponse>($"{BaseRequestUri}/{id}")
                .ConfigureAwait(false);
        }

        public async Task<StorefrontResponse> GetStorefronts(IReadOnlyCollection<string> ids)
        {
            if (ids == null || !ids.Any()) 
                throw new ArgumentNullException(nameof(ids));

            return await Get<StorefrontResponse>(BaseRequestUri, new Dictionary<string, string> {{"ids", string.Join(",", ids)}})
                .ConfigureAwait(false);
        }

        public async Task<StorefrontResponse> GetAllStorefronts(PageOptions pageOptions = null)
        {
            return await Get<StorefrontResponse>(BaseRequestUri, pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        public async Task<StorefrontResponse> GetUsersStorefront(string userToken)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await Get<StorefrontResponse>(BaseMeRequestUri)
                .ConfigureAwait(false);
        }
    }
}
