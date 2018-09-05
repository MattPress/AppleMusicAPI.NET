using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    /// <summary>
    /// Storefronts client contract.
    /// </summary>
    public interface IStorefrontsClient : IBaseClient
    {
        /// <summary>
        /// Fetch a single storefront by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_storefront
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StorefrontResponse> GetStorefront(string id);

        /// <summary>
        /// Fetch one or more storefronts by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_storefronts
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<StorefrontResponse> GetStorefronts(IReadOnlyCollection<string> ids);

        /// <summary>
        /// Fetch all the storefronts in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_storefronts
        /// </summary>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<StorefrontResponse> GetAllStorefronts(PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a user’s storefront.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_user_s_storefront
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        Task<StorefrontResponse> GetUsersStorefront(string userToken);
    }
}