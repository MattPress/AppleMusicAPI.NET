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
    /// <summary>
    /// Storefronts client.
    /// </summary>
    public class StorefrontsClient : BaseClient, IStorefrontsClient
    {
        private const string BaseRequestUri = "storefronts";

        public StorefrontsClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        #region storefronts/{id} 

        /// <summary>
        /// Fetch a single storefront by using its identifier.
        /// Route: storefronts/{id} 
        /// https://developer.apple.com/documentation/applemusicapi/get_a_storefront
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StorefrontResponse> GetStorefront(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await Get<StorefrontResponse>($"{BaseRequestUri}/{id}")
                .ConfigureAwait(false);
        }

        #endregion

        #region storefronts

        /// <summary>
        /// Fetch one or more storefronts by using their identifiers.
        /// Route: storefronts
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_storefronts
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<StorefrontResponse> GetStorefronts(IReadOnlyCollection<string> ids)
        {
            if (ids == null || !ids.Any()) 
                throw new ArgumentNullException(nameof(ids));

            return await Get<StorefrontResponse>(BaseRequestUri, new Dictionary<string, string> {{"ids", string.Join(",", ids)}})
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the storefronts in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_storefronts
        /// </summary>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<StorefrontResponse> GetAllStorefronts(PageOptions pageOptions = null)
        {
            return await Get<StorefrontResponse>(BaseRequestUri, pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        #endregion
    }
}