using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class RatingsClient : BaseClient
    {
        private const string BaseRequestUri = "me/ratings";

        public RatingsClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        public async Task<RatingResponse> GetPersonalAlbumRating(string userToken, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.Albums, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalMusicVideoRating(string userToken, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.MusicVideos, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalPlaylistRating(string userToken, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.Playlists, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalSongRating(string userToken, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.Songs, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalStationRating(string userToken, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.Stations, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalLibraryMusicVideoRating(string userToken, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetLibraryRating(userToken, Library.MusicVideos, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalLibraryPlaylistRating(string userToken, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetLibraryRating(userToken, Library.Playlists, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalLibrarySongRating(string userToken, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetLibraryRating(userToken, Library.Songs, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalAlbumRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.Albums, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalMusicVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.MusicVideos, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalPlaylistRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.Playlists, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalSongRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.Songs, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalStationRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.Stations, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalLibraryMusicVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleLibraryRatings(userToken, Library.MusicVideos, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalPlaylistVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleLibraryRatings(userToken, Library.Playlists, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalLibrarySongRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleLibraryRatings(userToken, Library.Songs, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> AddPersonalAlbumRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddCatalogRating(userToken, Catalog.Albums, id, request)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> AddPersonalMusicVideoRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddCatalogRating(userToken, Catalog.MusicVideos, id, request)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> AddPersonalPlaylistRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddCatalogRating(userToken, Catalog.Playlists, id, request)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> AddPersonalSongRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddCatalogRating(userToken, Catalog.Songs, id, request)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> AddPersonalStationRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddCatalogRating(userToken, Catalog.Stations, id, request)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> AddPersonalLibraryMusicVideoRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddLibraryRating(userToken, Library.MusicVideos, id, request)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> AddPersonalLibraryPlaylistRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddLibraryRating(userToken, Library.Playlists, id, request)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> AddPersonalLibrarySongRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddLibraryRating(userToken, Library.Songs, id, request)
                .ConfigureAwait(false);
        }

        public async Task<ResponseRoot> DeletePersonalAlbumRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.Albums, id)
                .ConfigureAwait(false);
        }

        public async Task<ResponseRoot> DeletePersonalMusicVideoRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.MusicVideos, id)
                .ConfigureAwait(false);
        }

        public async Task<ResponseRoot> DeletePersonalPlaylistRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.Playlists, id)
                .ConfigureAwait(false);
        }

        public async Task<ResponseRoot> DeletePersonalSongRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.Songs, id)
                .ConfigureAwait(false);
        }

        public async Task<ResponseRoot> DeletePersonalStationRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.Stations, id)
                .ConfigureAwait(false);
        }

        public async Task<ResponseRoot> DeletePersonalLibraryMusicVideoRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteLibraryRating(userToken, Library.MusicVideos, id)
                .ConfigureAwait(false);
        }

        public async Task<ResponseRoot> DeletePersonalLibraryPlaylistRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteLibraryRating(userToken, Library.Playlists, id)
                .ConfigureAwait(false);
        }

        public async Task<ResponseRoot> DeletePersonalLibrarySongRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteLibraryRating(userToken, Library.Songs, id)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> GetCatalogRating(string userToken, Catalog catalog, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude)
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();
            if (resourceTypesToInclude != null && resourceTypesToInclude.Any())
                queryString.Add("include", string.Join(",", resourceTypesToInclude.Select(x => x.ToString().ToLower().ToList())));

            return await Get<RatingResponse>($"{BaseRequestUri}/{catalog.GetValue()}/{id}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> GetLibraryRating(string userToken, Library library, string id, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();
            if (resourceTypesToInclude != null && resourceTypesToInclude.Any())
                queryString.Add("include", string.Join(",", resourceTypesToInclude.Select(x => x.ToString().ToLower().ToList())));

            return await Get<RatingResponse>($"{BaseRequestUri}/{library.ToLibraryString()}/{id}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> GetMultipleCatalogRatings(string userToken, Catalog catalog, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>
            {
                { "ids", string.Join(",", ids) }
            };

            if (resourceTypesToInclude != null && resourceTypesToInclude.Any())
                queryString.Add("include", string.Join(",", resourceTypesToInclude.Select(x => x.ToString().ToLower().ToList())));

            return await Get<RatingResponse>($"{BaseRequestUri}/{catalog.GetValue()}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> GetMultipleLibraryRatings(string userToken, Library library, IReadOnlyCollection<string> ids, IReadOnlyCollection<ResourceType> resourceTypesToInclude = null)
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>
            {
                { "ids", string.Join(",", ids) }
            };

            if (resourceTypesToInclude != null && resourceTypesToInclude.Any())
                queryString.Add("include", string.Join(",", resourceTypesToInclude.Select(x => x.ToString().ToLower().ToList())));

            return await Get<RatingResponse>($"{BaseRequestUri}/{library.ToLibraryString()}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> AddCatalogRating(string userToken, Catalog catalog, string id, RatingRequest request)
        {
            SetUserTokenHeader(userToken);

            return await Put<RatingResponse, RatingRequest>($"{BaseRequestUri}/{catalog.GetValue()}/{id}", request)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> AddLibraryRating(string userToken, Library library, string id, RatingRequest request)
        {
            SetUserTokenHeader(userToken);

            return await Put<RatingResponse, RatingRequest>($"{BaseRequestUri}/{library.ToLibraryString()}/{id}", request)
                .ConfigureAwait(false);
        }

        private async Task<ResponseRoot> DeleteCatalogRating(string userToken, Catalog catalog, string id)
        {
            SetUserTokenHeader(userToken);

            return await Delete($"{BaseRequestUri}/{catalog.GetValue()}/{id}")
                .ConfigureAwait(false);
        }

        private async Task<ResponseRoot> DeleteLibraryRating(string userToken, Library library, string id)
        {
            SetUserTokenHeader(userToken);

            return await Delete($"{BaseRequestUri}/{library.ToLibraryString()}/{id}")
                .ConfigureAwait(false);
        }
    }
}
