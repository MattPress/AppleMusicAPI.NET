using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    /// <summary>
    /// Recent history client.
    /// </summary>
    public class RecentHistoryClient : BaseClient, IRecentHistoryClient
    {
        public RecentHistoryClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        /// <summary>
        /// Fetch the resources in heavy rotation for the user.
        /// https://developer.apple.com/documentation/applemusicapi/get_heavy_rotation_content
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<HistoryResponse> GetHeavyRotationContent(string userToken, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await Get<HistoryResponse>($"me/history/heavy-rotation", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the recently played resources for the user.
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_played_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<HistoryResponse> GetRecentlyPlayedResources(string userToken, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await Get<HistoryResponse>($"me/recent/played", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch recently played radio stations for the user.
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_played_stations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<HistoryResponse> GetRecentlyPlayedStations(string userToken, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await Get<HistoryResponse>($"me/recent/radio-stations", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the resources recently added to the library.
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_added_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> GetRecentlyAddedResources(string userToken, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await Get<ResponseRoot>($"me/library/recently-added", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }
    }
}
