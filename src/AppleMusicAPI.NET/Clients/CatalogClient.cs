using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class CatalogClient : BaseClient
    {
        private const string BaseRequestUri = "catalog";

        public CatalogClient(HttpClient client, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(client, jsonSerializer, jwtProvider)
        {
        }

        #region Route: GET catalog/{storefront}/charts

        /// <summary>
        /// Fetch one or more charts from the Apple Music Catalog.
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_charts
        /// </summary>
        /// <returns></returns>
        public async Task<ChartResponse> GetCatalogCharts(string storefront, IReadOnlyCollection<CatalogChartType> types = null, string chart = null, string genre = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();
            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            if (!string.IsNullOrWhiteSpace(chart))
                queryString.Add("chart", chart);

            if (!string.IsNullOrWhiteSpace(genre))
                queryString.Add("genre", genre);

            return await Get<ChartResponse>($"{BaseRequestUri}/{storefront}/charts", queryString, pageOptions);
        }

        #endregion

        #region Route: GET catalog/{storefront}/search

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

            return await Get<SearchResponse>($"{BaseRequestUri}/{storefront}/search", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: GET catalog/{storefront}/search/hints

        /// <summary>
        /// Fetch the search term results for a hint.
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_search_hints
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<SearchHintsResponse> GetCatalogSearchHints(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(term))
                queryString.Add("term", term.Replace(' ', '+'));

            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            return await Get<SearchHintsResponse>($"{BaseRequestUri}/{storefront}/search/hints", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion
    }
}
