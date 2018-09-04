using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    /// <summary>
    /// Charts client.
    /// </summary>
    public class ChartsClient : BaseClient, IChartsClient
    {
        private const string BaseRequestUri = "catalog";

        public ChartsClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        /// <summary>
        /// Get Catalog Charts.
        /// Fetch one or more charts from the Apple Music Catalog.
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
    }
}
