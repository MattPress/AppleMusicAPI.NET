using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class CatalogClient : BaseClient, ICatalogClient
    {
        private const string BaseRequestUri = "catalog";

        public CatalogClient(HttpClient client, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(client, jsonSerializer, jwtProvider)
        {
        }

        #region Route: catalog/{storefront}/activities/{id}

        /// <summary>
        /// Fetch an activity by using its identifier.
        /// Route: catalog/{storefront}/activities/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_activity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<ActivityResponse> GetCatalogActivity(string id, string storefront, IReadOnlyCollection<ActivityRelationship> relationshipsToInclude = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<ActivityResponse, ActivityRelationship>(ResourceType.Activities, id, storefront, relationshipsToInclude, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/activities/{id}/{relationship}

        /// <summary>
        /// Fetch an activity's relationship by using its identifier.
        /// Route: catalog/{storefront}/activities/{id}/{relationship}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_activity_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<ActivityResponse> GetCatalogActivityRelationship(string id, string storefront, ActivityRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<ActivityResponse, ActivityRelationship>(ResourceType.Activities, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/activities

        /// <summary>
        /// Fetch one or more activities by using their identifiers.
        /// Route: catalog/{storefront}/activities
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_activities
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<ActivityResponse> GetMultipleCatalogActivities(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ActivityRelationship> include = null, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<ActivityResponse, ActivityRelationship>(ResourceType.Activities, ids, storefront, include, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/albums/{id}

        /// <summary>
        /// Fetch an album by using its identifier.
        /// Route: catalog/{storefront}/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_album
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<AlbumResponse> GetCatalogAlbum(string id, string storefront, IReadOnlyCollection<AlbumRelationship> relationshipsToInclude = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<AlbumResponse, AlbumRelationship>(ResourceType.Albums, id, storefront, relationshipsToInclude, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/albums/{id}/{relationship}

        /// <summary>
        /// Fetch an album's relationship by using its identifier.
        /// Route: catalog/{storefront}/albums/{id}/{relationship}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_album_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<AlbumResponse> GetCatalogAlbumRelationship(string id, string storefront, AlbumRelationship relationship, int? limit = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<AlbumResponse, AlbumRelationship>(ResourceType.Albums, id, storefront, relationship, limit, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/albums

        /// <summary>
        /// Fetch one or more albums by using their identifiers.
        /// Route: catalog/{storefront}/albums
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_albums
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<AlbumResponse> GetMultipleCatalogAlbums(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AlbumRelationship> include = null, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<AlbumResponse, AlbumRelationship>(ResourceType.Albums, ids, storefront, include, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/apple-curators/{id}

        /// <summary>
        /// Fetch an Apple curator by using the curator's identifier.
        /// Route: catalog/{storefront}/apple-curators/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_apple_curator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<AppleCuratorResponse> GetCatalogAppleCurator(string id, string storefront, IReadOnlyCollection<AppleCuratorRelationship> relationshipsToInclude = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<AppleCuratorResponse, AppleCuratorRelationship>(ResourceType.AppleCurators, id, storefront, relationshipsToInclude, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/apple-curators/{id}/{relationship}

        /// <summary>
        /// Fetch an Apple curator's relationship by using the curator's identifier.
        /// Route: catalog/{storefront}/apple-curators/{id}/{relationship}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_apple_curator_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<AppleCuratorResponse> GetCatalogAppleCuratorRelationship(string id, string storefront, AppleCuratorRelationship relationship, int? limit = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<AppleCuratorResponse, AppleCuratorRelationship>(ResourceType.AppleCurators, id, storefront, relationship, limit, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/apple-curators

        /// <summary>
        /// Fetch one or more Apple curators by using their identifiers.
        /// Route: catalog/{storefront}/apple-curators
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_apple_curators
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<AppleCuratorResponse> GetMultipleCatalogAppleCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AppleCuratorRelationship> include = null, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<AppleCuratorResponse, AppleCuratorRelationship>(ResourceType.AppleCurators, ids, storefront, include, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/artists/{id}

        /// <summary>
        /// Fetch an artist by using the artist's identifier.
        /// Route: catalog/{storefront}/artists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_artist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<ArtistResponse> GetCatalogArtist(string id, string storefront, IReadOnlyCollection<ArtistRelationship> relationshipsToInclude = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<ArtistResponse, ArtistRelationship>(ResourceType.Artists, id, storefront, relationshipsToInclude, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/artists/{id}/{relationship}

        /// <summary>
        /// Fetch an artist's relationship by using the artist's identifier.
        /// Route: catalog/{storefront}/artists/{id}/{relationship}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_artist_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<ArtistResponse> GetCatalogArtistRelationship(string id, string storefront, ArtistRelationship relationship, int? limit = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<ArtistResponse, ArtistRelationship>(ResourceType.Artists, id, storefront, relationship, limit, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/artists

        /// <summary>
        /// Fetch one or more artists by using their identifiers.
        /// Route: catalog/{storefront}/artists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_artists
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<ArtistResponse> GetMultipleCatalogArtists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ArtistRelationship> include = null, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<ArtistResponse, ArtistRelationship>(ResourceType.Artists, ids, storefront, include, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/charts

        /// <summary>
        /// Fetch one or more charts from the Apple Music Catalog.
        /// Route: catalog/{storefront}/charts
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_charts
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="types"></param>
        /// <param name="chart"></param>
        /// <param name="genre"></param>
        /// <param name="pageOptions"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<ChartResponse> GetCatalogCharts(string storefront, IReadOnlyCollection<CatalogChartType> types = null, string chart = null, string genre = null, PageOptions pageOptions = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();
            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            if (!string.IsNullOrWhiteSpace(chart))
                queryString.Add("chart", chart);

            if (!string.IsNullOrWhiteSpace(genre))
                queryString.Add("genre", genre);

            return await Get<ChartResponse>($"{BaseRequestUri}/{storefront}/charts", queryString, pageOptions, locale);
        }

        #endregion

        #region Route: catalog/{storefront}/curators/{id}

        /// <summary>
        /// Fetch a curator by using the curator's identifier.
        /// Route: catalog/{storefront}/curators/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_curator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<CuratorResponse> GetCatalogCurator(string id, string storefront, IReadOnlyCollection<CuratorRelationship> relationshipsToInclude = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<CuratorResponse, CuratorRelationship>(ResourceType.Curators, id, storefront, relationshipsToInclude, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/curators/{id}/{relationship}

        /// <summary>
        /// Fetch a curator's relationship by using the curator's identifier.
        /// Route: catalog/{storefront}/curators/{id}/{relationship}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_curator_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<CuratorResponse> GetCatalogCuratorRelationship(string id, string storefront, CuratorRelationship relationship, int? limit = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<CuratorResponse, CuratorRelationship>(ResourceType.Curators, id, storefront, relationship, limit, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/curators

        /// <summary>
        /// Fetch one or more curators by using their identifiers.
        /// Route: catalog/{storefront}/curators
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_curators
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<CuratorResponse> GetMultipleCatalogCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<CuratorRelationship> include = null, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<CuratorResponse, CuratorRelationship>(ResourceType.Curators, ids, storefront, include, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/genres/{id}

        /// <summary>
        /// Fetch a genre by using its identifier.
        /// Route: catalog/{storefront}/genres/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_genre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<GenreResponse> GetCatalogGenre(string id, string storefront, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<GenreResponse>(ResourceType.Genres, id, storefront, locale: locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/genres

        /// <summary>
        /// Fetch one or more genres.
        /// Route: catalog/{storefront}/genres
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_genres
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<GenreResponse> GetMultipleCatalogGenres(IReadOnlyCollection<string> ids, string storefront, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>
            {
                {"ids", string.Join(",", ids)}
            };

            return await GetMultipleCatalogResources<GenreResponse>(ResourceType.Genres, storefront, queryString, locale)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all genres for the current top charts.
        /// Route: catalog/{storefront}/genres
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_top_charts_genres
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="pageOptions"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<GenreResponse> GetCatalogTopChartsGenres(string storefront, PageOptions pageOptions = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await Get<GenreResponse>($"{BaseRequestUri}/{storefront}/{ResourceType.Genres.GetValue()}", pageOptions: pageOptions, locale: locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/music-videos/{id}

        /// <summary>
        /// Fetch a music video by using its identifier.
        /// Route: catalog/{storefront}/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_music_video
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<MusicVideoResponse> GetCatalogMusicVideo(string id, string storefront, IReadOnlyCollection<MusicVideoRelationship> relationshipsToInclude = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<MusicVideoResponse, MusicVideoRelationship>(ResourceType.MusicVideos, id, storefront, relationshipsToInclude, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/music-videos/{id}/{relationship}

        /// <summary>
        /// Fetch a music video's relationship by using its identifier.
        /// Route: catalog/{storefront}/music-videos/{id}/{relationship}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_music_video_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<MusicVideoResponse> GetCatalogMusicVideoRelationship(string id, string storefront, MusicVideoRelationship relationship, int? limit = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<MusicVideoResponse, MusicVideoRelationship>(ResourceType.MusicVideos, id, storefront, relationship, limit, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/music-videos

        /// <summary>
        /// Fetch one or more music videos by using their identifiers.
        /// Route: catalog/{storefront}/music-videos
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_music_videos_by_id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="isrc"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<MusicVideoResponse> GetMultipleCatalogMusicVideos(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<MusicVideoRelationship> include = null, string isrc = null, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(isrc))
                queryString.Add("filter[isrc]", isrc);

            return await GetMultipleCatalogResources<MusicVideoResponse, MusicVideoRelationship>(ResourceType.MusicVideos, ids, storefront, include, locale, queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more music videos by using their ISRC values.
        /// Route: catalog/{storefront}/music-videos
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_music_videos_by_isrc
        /// </summary>
        /// <param name="isrc"></param>
        /// <param name="storefront"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<MusicVideoResponse> GetMultipleCatalogMusicVideosByIsrc(string isrc, string storefront, IReadOnlyCollection<string> ids = null, IReadOnlyCollection<MusicVideoRelationship> include = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(isrc))
                throw new ArgumentNullException(nameof(isrc));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>()
            {
                {"filter[isrc]", isrc},
            };

            return await GetMultipleCatalogResources<MusicVideoResponse, MusicVideoRelationship>(ResourceType.MusicVideos, ids, storefront, include, locale, queryString)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/playlists/{id}

        /// <summary>
        /// Fetch a playlist by using its identifier.
        /// Route: catalog/{storefront}/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_playlist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<PlaylistResponse> GetCatalogPlaylist(string id, string storefront, IReadOnlyCollection<PlaylistRelationship> relationshipsToInclude = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<PlaylistResponse, PlaylistRelationship>(ResourceType.Playlists, id, storefront, relationshipsToInclude, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/playlists/{id}/{relationship}

        /// <summary>
        /// Fetch a playlist's relationship by using its identifier.
        /// Route: catalog/{storefront}/playlists/{id}/{relationship}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_playlist_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<PlaylistResponse> GetCatalogPlaylistRelationship(string id, string storefront, PlaylistRelationship relationship, int? limit = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<PlaylistResponse, PlaylistRelationship>(ResourceType.Playlists, id, storefront, relationship, limit, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/playlists

        /// <summary>
        /// Fetch one or more playlists by using their identifiers.
        /// Route: catalog/{storefront}/playlists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_playlists
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<PlaylistResponse> GetMultipleCatalogPlaylists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<PlaylistRelationship> include = null, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<PlaylistResponse, PlaylistRelationship>(ResourceType.Playlists, ids, storefront, include, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/search

        /// <summary>
        /// Search the catalog by using a query.
        /// Route: catalog/{storefront}/search
        /// https://developer.apple.com/documentation/applemusicapi/search_for_catalog_resources
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<SearchResponse> CatalogResourcesSearch(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(term))
                queryString.Add("term", term.Replace(' ', '+'));

            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            return await Get<SearchResponse>($"{BaseRequestUri}/{storefront}/search", queryString, pageOptions, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/search/hints

        /// <summary>
        /// Fetch the search term results for a hint.
        /// Route: catalog/{storefront}/search/hints
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_search_hints
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<SearchHintsResponse> GetCatalogSearchHints(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(term))
                queryString.Add("term", term.Replace(' ', '+'));

            if (types != null && types.Any())
                queryString.Add("types", string.Join(",", types.Select(x => x.GetValue())));

            return await Get<SearchHintsResponse>($"{BaseRequestUri}/{storefront}/search/hints", queryString, pageOptions, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/songs

        /// <summary>
        /// Fetch a song by using its identifier.
        /// Route: catalog/{storefront}/songs
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_song
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<SongResponse> GetCatalogSong(string id, string storefront, IReadOnlyCollection<SongRelationship> relationshipsToInclude = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<SongResponse, SongRelationship>(ResourceType.Songs, id, storefront, relationshipsToInclude, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/songs/{id}/{relationship}

        /// <summary>
        /// Fetch a song's relationship by using its identifier.
        /// Route: catalog/{storefront}/songs/{id}/{relationship}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_song_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<SongResponse> GetCatalogSongRelationship(string id, string storefront, SongRelationship relationship, int? limit = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<SongResponse, SongRelationship>(ResourceType.Songs, id, storefront, relationship, limit, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/songs

        /// <summary>
        /// Fetch one or more songs by using their identifiers.
        /// Route: catalog/{storefront}/songs
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_songs_by_id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="isrc"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<SongResponse> GetMultipleCatalogSongs(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<SongRelationship> include = null, string isrc = null, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(isrc))
                queryString.Add("filter[isrc]", isrc);

            return await GetMultipleCatalogResources<SongResponse, SongRelationship>(ResourceType.Songs, ids, storefront, include, locale, queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more songs by using their ISRC values.
        /// Route: catalog/{storefront}/songs
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_songs_by_isrc
        /// </summary>
        /// <param name="isrc"></param>
        /// <param name="storefront"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<SongResponse> GetMultipleCatalogSongsByIsrc(string isrc, string storefront, IReadOnlyCollection<string> ids = null, IReadOnlyCollection<SongRelationship> include = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(isrc))
                throw new ArgumentNullException(nameof(isrc));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>()
            {
                {"filter[isrc]", isrc},
            };

            return await GetMultipleCatalogResources<SongResponse, SongRelationship>(ResourceType.Songs, ids, storefront, include, locale, queryString)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/stations/{id}

        /// <summary>
        /// Fetch a station by using its identifier.
        /// Route: catalog/{storefront}/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_station
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<StationResponse> GetCatalogStation(string id, string storefront, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<StationResponse>(ResourceType.Stations, id, storefront, locale: locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Route: catalog/{storefront}/stations

        /// <summary>
        /// Fetch one or more stations by using their identifiers.
        /// Route: catalog/{storefront}/stations
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_stations
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<StationResponse> GetMultipleCatalogStations(IReadOnlyCollection<string> ids, string storefront, string locale = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>
            {
                {"ids", string.Join(",", ids)}
            };

            return await GetMultipleCatalogResources<StationResponse>(ResourceType.Stations, storefront, queryString, locale)
                .ConfigureAwait(false);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Fetch a catalog resource by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="resourceType"></param>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="queryString"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        private async Task<TResponse> GetCatalogResource<TResponse>(ResourceType resourceType, string id, string storefront, Dictionary<string, string> queryString = null, string locale = null)
        {
            return await Get<TResponse>($"{BaseRequestUri}/{storefront}/{resourceType.GetValue()}/{id}", queryString, locale: locale)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a catalog resource by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="resourceType"></param>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        private async Task<TResponse> GetCatalogResource<TResponse, TRelationshipEnum>(ResourceType resourceType, string id, string storefront, IReadOnlyCollection<TRelationshipEnum> relationshipsToInclude = null, string locale = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();
            if (relationshipsToInclude != null && relationshipsToInclude.Any())
                queryString.Add("include", string.Join(",", relationshipsToInclude.Select(x => x.GetValue())));

            return await GetCatalogResource<TResponse>(resourceType, id, storefront, queryString, locale)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a catalog resource's relationship by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="resourceType"></param>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        private async Task<TResponse> GetCatalogResourceRelationship<TResponse, TRelationshipEnum>(ResourceType resourceType, string id, string storefront, TRelationshipEnum relationship, int? limit = null, string locale = null)
            where TRelationshipEnum : IConvertible
        {
            var pageOptions = new PageOptions
            {
                Limit = limit
            };

            return await Get<TResponse>($"{BaseRequestUri}/{storefront}/{resourceType.GetValue()}/{id}/{relationship.GetValue()}", pageOptions: pageOptions, locale: locale)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more catalog resources by using their identifiers.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="resourceType"></param>
        /// <param name="storefront"></param>
        /// <param name="queryString"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        private async Task<TResponse> GetMultipleCatalogResources<TResponse>(ResourceType resourceType, string storefront, IDictionary<string, string> queryString = null, string locale = null)
        {
            return await Get<TResponse>($"{BaseRequestUri}/{storefront}/{resourceType.GetValue()}", queryString, locale: locale)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more catalog resources by using their identifiers.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="resourceType"></param>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="locale"></param>
        /// <param name="additionalQuerystringParams"></param>
        /// <returns></returns>
        private async Task<TResponse> GetMultipleCatalogResources<TResponse, TRelationshipEnum>(ResourceType resourceType, IEnumerable<string> ids, string storefront, IReadOnlyCollection<TRelationshipEnum> include = null, string locale = null, IDictionary<string, string> additionalQuerystringParams = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();

            if (ids != null && ids.Any())
                queryString.Add("ids", string.Join(",", ids));

            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            if (additionalQuerystringParams != null && additionalQuerystringParams.Any())
                queryString.Merge(additionalQuerystringParams);

            return await GetMultipleCatalogResources<TResponse>(resourceType, storefront, queryString, locale)
                .ConfigureAwait(false);
        }

        #endregion
    }
}
