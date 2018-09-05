using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    /// <summary>
    /// Search client contract.
    /// </summary>
    public interface ISearchClient : IBaseClient
    {
        /// <summary>
        /// Search the catalog by using a query.
        /// https://developer.apple.com/documentation/applemusicapi/search_for_catalog_resources
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<SearchResponse> CatalogResourcesSearch(string storefront, string term = null, IReadOnlyCollection<CatalogResource> types = null, PageOptions pageOptions = null);

        /// <summary>
        /// Search the library by using a query.
        /// https://developer.apple.com/documentation/applemusicapi/search_for_library_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<SearchResponse> LibraryResourcesSearch(string userToken, string term = null, IReadOnlyCollection<Library> types = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch the search term results for a hint.
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_search_hints
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<SearchResponse> GetCatalogSearchHints(string storefront, string term = null, IReadOnlyCollection<CatalogResource> types = null, PageOptions pageOptions = null);
    }
}