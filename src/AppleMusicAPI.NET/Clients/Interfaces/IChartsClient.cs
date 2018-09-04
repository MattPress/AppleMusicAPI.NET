using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    public interface IChartsClient
    {
        /// <summary>
        /// Get Catalog Charts.
        /// Fetch one or more charts from the Apple Music Catalog.
        /// </summary>
        /// <returns></returns>
        Task<ChartResponse> GetCatalogCharts(string storefront, IReadOnlyCollection<CatalogChartType> types = null, string chart = null, string genre = null, PageOptions pageOptions = null);
    }
}