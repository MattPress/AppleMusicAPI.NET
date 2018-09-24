using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    /// <summary>
    /// Recent history client contract.
    /// </summary>
    public interface IRecentHistoryClient : IBaseClient
    {
        /// <summary>
        /// Fetch the resources in heavy rotation for the user.
        /// https://developer.apple.com/documentation/applemusicapi/get_heavy_rotation_content
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<HistoryResponse> GetHeavyRotationContent(string userToken, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch the recently played resources for the user.
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_played_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<HistoryResponse> GetRecentlyPlayedResources(string userToken, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch recently played radio stations for the user.
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_played_stations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<HistoryResponse> GetRecentlyPlayedStations(string userToken, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch the resources recently added to the library.
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_added_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<RecentlyAddedResponse> GetRecentlyAddedResources(string userToken, PageOptions pageOptions = null);
    }
}