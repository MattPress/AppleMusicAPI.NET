using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    /// <summary>
    /// Charts client contract.
    /// </summary>
    public interface IChartsClient : IBaseClient
    {
        /// <summary>
        /// Fetch one or more charts from the Apple Music Catalog.
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_charts
        /// </summary>
        /// <returns></returns>
        Task<ChartResponse> GetCatalogCharts(string storefront, IReadOnlyCollection<CatalogChartType> types = null, string chart = null, string genre = null, PageOptions pageOptions = null);
    }
}