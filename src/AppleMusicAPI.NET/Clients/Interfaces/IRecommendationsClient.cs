using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    /// <summary>
    /// Recommendations client contract.
    /// </summary>
    public interface IRecommendationsClient : IBaseClient
    {
        /// <summary>
        /// Fetch a recommendation by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_recommendation
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<RecommendationResponse> GetRecommendation(string userToken, string id, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch one or more recommendations by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_recommendations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<RecommendationResponse> GetMultipleRecommendations(string userToken, IReadOnlyCollection<string> ids, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch default recommendations.
        /// https://developer.apple.com/documentation/applemusicapi/get_default_recommendations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="recommendationsType"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<RecommendationResponse> GetDefaultRecommendations(string userToken, RecommendationsType? recommendationsType = null, PageOptions pageOptions = null);
    }
}