using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class MeClient : BaseClient
    {
        private const string BaseRequestUri = "me";

        public MeClient(HttpClient client, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(client, jsonSerializer, jwtProvider)
        {
        }

        #region Route: POST me/library

        /// <summary>
        /// Add a catalog resource to a user’s iCloud Music Library.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_resource_to_a_library
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> AddResourceToLibrary(string userToken, IReadOnlyDictionary<iCloudMusicLibraryType, List<string>> ids)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any(x => x.Value.Any()))
                throw new ArgumentNullException(nameof(ids));

            SetUserTokenHeader(userToken);

            var queryString = ids
                .Where(x => x.Value.Any(y => !string.IsNullOrWhiteSpace(y)))
                .ToDictionary(x => $"ids[{x.Key.GetValue()}]", x => string.Join(",", x.Value.Where(y => !string.IsNullOrWhiteSpace(y))));

            return await Post<ResponseRoot>($"{BaseRequestUri}/library", queryString);
        }

        #endregion

        #region Route: POST me/library/playlists

        /// <summary>
        /// Create a new playlist in a user’s library.
        /// https://developer.apple.com/documentation/applemusicapi/create_a_new_library_playlist
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="request"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryPlaylistResponse> CreateLibraryPlaylist(string userToken, LibraryPlaylistCreationRequest request, IReadOnlyCollection<LibraryPlaylistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();
            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            return await Post<LibraryPlaylistResponse, LibraryPlaylistCreationRequest>($"{BaseRequestUri}/library/playlists", request, queryString)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: GET me/library/search

        /// <summary>
        /// Search the library by using a query.
        /// https://developer.apple.com/documentation/applemusicapi/search_for_library_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<LibrarySearchResponse> LibraryResourcesSearch(string userToken, string term = null, IReadOnlyCollection<LibraryResource> types = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(term))
                queryString.Add("term", term.Replace(' ', '+'));

            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            return await Get<LibrarySearchResponse>($"{BaseRequestUri}/library/search", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: GET me/recommendations/{id}

        /// <summary>
        /// Fetch a recommendation by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_recommendation
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<RecommendationResponse> GetRecommendation(string userToken, string id, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await Get<RecommendationResponse>($"{BaseRequestUri}/recommendations/{id}", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: GET me/recommendations

        /// <summary>
        /// Fetch one or more recommendations by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_recommendations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<RecommendationResponse> GetMultipleRecommendations(string userToken, IReadOnlyCollection<string> ids, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>
                {
                    { "ids", string.Join(",", ids) }
                };

            return await Get<RecommendationResponse>($"{BaseRequestUri}/recommendations", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch default recommendations.
        /// https://developer.apple.com/documentation/applemusicapi/get_default_recommendations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="recommendationType"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<RecommendationResponse> GetDefaultRecommendations(string userToken, RecommendationType? recommendationType = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();

            if (recommendationType.HasValue)
            {
                queryString.Add("type", recommendationType.Value.GetValue());
            };

            return await Get<RecommendationResponse>($"{BaseRequestUri}/recommendations", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: GET me/storefront

        /// <summary>
        /// Fetch a user’s storefront.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_user_s_storefront
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public async Task<StorefrontResponse> GetUsersStorefront(string userToken)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await Get<StorefrontResponse>($"{BaseRequestUri}/storefront")
                .ConfigureAwait(false);
        }

        #endregion
    }
}
