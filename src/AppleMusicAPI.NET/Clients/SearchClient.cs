using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    /// <summary>
    /// Search client.
    /// </summary>
    public class SearchClient : BaseClient, ISearchClient
    {
        public SearchClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        /// <summary>
        /// Search the catalog by using a query.
        /// https://developer.apple.com/documentation/applemusicapi/search_for_catalog_resources
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<SearchResponse> CatalogResourcesSearch(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(term))
                queryString.Add("term", term.Replace(' ', '+'));

            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            return await Get<SearchResponse>($"catalog/{storefront}/search", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Search the library by using a query.
        /// https://developer.apple.com/documentation/applemusicapi/search_for_library_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<SearchResponse> LibraryResourcesSearch(string userToken, string term = null, IReadOnlyCollection<LibraryResource> types = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(term))
                queryString.Add("term", term.Replace(' ', '+'));

            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            return await Get<SearchResponse>("me/library/search", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the search term results for a hint.
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_search_hints
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<SearchResponse> GetCatalogSearchHints(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(term))
                queryString.Add("term", term.Replace(' ', '+'));

            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            return await Get<SearchResponse>($"catalog/{storefront}/search/hints", queryString, pageOptions)
                .ConfigureAwait(false);
        }
    }
}
