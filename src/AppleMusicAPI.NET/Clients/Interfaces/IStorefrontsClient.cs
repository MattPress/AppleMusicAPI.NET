using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    public interface IStorefrontsClient
    {
        /// <summary>
        /// Fetch a single storefront by using its identifier.
        /// Route: storefronts/{id} 
        /// https://developer.apple.com/documentation/applemusicapi/get_a_storefront
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<StorefrontResponse> GetStorefront(string id, string locale = null);

        /// <summary>
        /// Fetch one or more storefronts by using their identifiers.
        /// Route: storefronts
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_storefronts
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<StorefrontResponse> GetStorefronts(IReadOnlyCollection<string> ids, string locale = null);

        /// <summary>
        /// Fetch all the storefronts in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_storefronts
        /// </summary>
        /// <param name="pageOptions"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<StorefrontResponse> GetAllStorefronts(PageOptions pageOptions = null, string locale = null);
    }
}