using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    /// <summary>
    /// Library playlists client.
    /// </summary>
    public class LibraryPlaylistsClient : BaseClient, ILibraryPlaylistsClient
    {
        private const string BaseRequestUri = "me/library/playlists";

        public LibraryPlaylistsClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

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

            return await Post<LibraryPlaylistResponse, LibraryPlaylistCreationRequest>(BaseRequestUri, request, queryString)
                .ConfigureAwait(false);
        }
    }
}
