using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    /// <summary>
    /// iCloud music library client.
    /// </summary>
#pragma warning disable IDE1006 // Naming Styles
    public class iCloudMusicLibraryClient : BaseClient, IiCloudMusicLibraryClient
#pragma warning restore IDE1006 // Naming Styles
    {
        private const string RequestUri = "me/library"; 

        public iCloudMusicLibraryClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

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

            var queryString = ids
                .Where(x => x.Value.Any(y => !string.IsNullOrWhiteSpace(y)))
                .ToDictionary(x => $"ids[{x.Key.GetValue()}]", x => string.Join(",", x.Value.Where(y => !string.IsNullOrWhiteSpace(y))));

            return await Post<ResponseRoot>(RequestUri, queryString);
        }
    }
}
