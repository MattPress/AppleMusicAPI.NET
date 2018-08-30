﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Enums;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class RatingsClient : BaseClient
    {
        private const string BaseRequestUri = "me/ratings";

        public RatingsClient(HttpClient httpClient, IJsonSerializer jsonSerializer) 
            : base(httpClient, jsonSerializer)
        {
        }

        public async Task<RatingResponse> GetPersonalAlbumRating(string userToken, string id, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.Albums, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalMusicVideoRating(string userToken, string id, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.MusicVideos, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalPlaylistRating(string userToken, string id, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.Playlists, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalSongRating(string userToken, string id, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.Songs, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalStationRating(string userToken, string id, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetCatalogRating(userToken, Catalog.Stations, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalLibraryMusicVideoRating(string userToken, string id, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetLibraryRating(userToken, Library.MusicVideos, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalLibraryPlaylistRating(string userToken, string id, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetLibraryRating(userToken, Library.Playlists, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetPersonalLibrarySongRating(string userToken, string id, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetLibraryRating(userToken, Library.Songs, id, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalAlbumRatings(string userToken, string[] ids, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.Albums, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalMusicVideoRatings(string userToken, string[] ids, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.MusicVideos, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalPlaylistRatings(string userToken, string[] ids, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.Playlists, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalSongRatings(string userToken, string[] ids, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.Songs, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalStationRatings(string userToken, string[] ids, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleCatalogRatings(userToken, Catalog.Stations, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalLibraryMusicVideoRatings(string userToken, string[] ids, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleLibraryRatings(userToken, Library.MusicVideos, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalPlaylistVideoRatings(string userToken, string[] ids, ResourceType[] resourceTypesToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleLibraryRatings(userToken, Library.Playlists, ids, resourceTypesToInclude)
                .ConfigureAwait(false);
        }

        public async Task<RatingResponse> GetMultiplePersonalLibrarySongRatings(string userToken, string[] ids, ResourceType[] resourceTypesToInclude = null)
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

        public async Task<bool> DeletePersonalAlbumRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.Albums, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeletePersonalMusicVideoRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.MusicVideos, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeletePersonalPlaylistRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.Playlists, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeletePersonalSongRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.Songs, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeletePersonalStationRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteCatalogRating(userToken, Catalog.Stations, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeletePersonalLibraryMusicVideoRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteLibraryRating(userToken, Library.MusicVideos, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeletePersonalLibraryPlaylistRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteLibraryRating(userToken, Library.Playlists, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeletePersonalLibrarySongRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteLibraryRating(userToken, Library.Songs, id)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> GetCatalogRating(string userToken, Catalog catalog, string id, ResourceType[] resourceTypesToInclude)
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();
            if (resourceTypesToInclude != null && resourceTypesToInclude.Any())
                queryString.Add("include", string.Join(",", resourceTypesToInclude.Select(x => x.ToString().ToLower().ToList())));

            return await Get<RatingResponse>($"{BaseRequestUri}/{catalog.ToCatalogString()}/{id}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> GetLibraryRating(string userToken, Library library, string id, ResourceType[] resourceTypesToInclude = null)
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();
            if (resourceTypesToInclude != null && resourceTypesToInclude.Any())
                queryString.Add("include", string.Join(",", resourceTypesToInclude.Select(x => x.ToString().ToLower().ToList())));

            return await Get<RatingResponse>($"{BaseRequestUri}/{library.ToLibraryString()}/{id}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> GetMultipleCatalogRatings(string userToken, Catalog catalog, string[] ids, ResourceType[] resourceTypesToInclude = null)
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>
            {
                { "ids", string.Join(",", ids) }
            };

            if (resourceTypesToInclude != null && resourceTypesToInclude.Any())
                queryString.Add("include", string.Join(",", resourceTypesToInclude.Select(x => x.ToString().ToLower().ToList())));

            return await Get<RatingResponse>($"{BaseRequestUri}/{catalog.ToCatalogString()}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> GetMultipleLibraryRatings(string userToken, Library library, string[] ids, ResourceType[] resourceTypesToInclude = null)
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

            return await Put<RatingResponse, RatingRequest>($"{BaseRequestUri}/{catalog.ToCatalogString()}/{id}", request)
                .ConfigureAwait(false);
        }

        private async Task<RatingResponse> AddLibraryRating(string userToken, Library library, string id, RatingRequest request)
        {
            SetUserTokenHeader(userToken);

            return await Put<RatingResponse, RatingRequest>($"{BaseRequestUri}/{library.ToLibraryString()}/{id}", request)
                .ConfigureAwait(false);
        }

        private async Task<bool> DeleteCatalogRating(string userToken, Catalog catalog, string id)
        {
            SetUserTokenHeader(userToken);

            return await Delete($"{BaseRequestUri}/{catalog.ToCatalogString()}/{id}")
                .ConfigureAwait(false);
        }

        private async Task<bool> DeleteLibraryRating(string userToken, Library library, string id)
        {
            SetUserTokenHeader(userToken);

            return await Delete($"{BaseRequestUri}/{library.ToLibraryString()}/{id}")
                .ConfigureAwait(false);
        }
    }
}