using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    /// <summary>
    /// Resource data client.
    /// </summary>
    public class ResourceDataClient : BaseClient, IResourceDataClient
    {
        private const string BaseCatalogRequestUri = "catalog";
        private const string BaseLibraryRequestUri = "me/library";

        public ResourceDataClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider)
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        #region Albums

        /// <summary>
        /// Fetch an album by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_album
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<AlbumResponse> GetCatalogAlbum(string id, string storefront, IReadOnlyCollection<AlbumRelationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<AlbumResponse, AlbumRelationship>(CatalogResource.Albums, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch an album's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_album_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<AlbumResponse> GetCatalogAlbumRelationship(string id, string storefront, AlbumRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<AlbumResponse, AlbumRelationship>(CatalogResource.Albums, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more albums by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_albums
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<AlbumResponse> GetMultipleCatalogAlbums(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AlbumRelationship> include = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<AlbumResponse, AlbumRelationship>(CatalogResource.Albums, ids, storefront, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region Music Videos

        /// <summary>
        /// Fetch a music video by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_music_video
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<MusicVideoResponse> GetCatalogMusicVideo(string id, string storefront, IReadOnlyCollection<MusicVideoRelationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<MusicVideoResponse, MusicVideoRelationship>(CatalogResource.MusicVideos, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a music video's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_music_video_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<MusicVideoResponse> GetCatalogMusicVideoRelationship(string id, string storefront, MusicVideoRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<MusicVideoResponse, MusicVideoRelationship>(CatalogResource.MusicVideos, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more music videos by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_music_videos_by_id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="isrc"></param>
        /// <returns></returns>
        public async Task<MusicVideoResponse> GetMultipleCatalogMusicVideos(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<MusicVideoRelationship> include = null, string isrc = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(isrc))
                queryString.Add("filter[isrc]", isrc);

            return await GetMultipleCatalogResources<MusicVideoResponse, MusicVideoRelationship>(CatalogResource.MusicVideos, ids, storefront, include, queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more music videos by using their ISRC values.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_music_videos_by_isrc
        /// </summary>
        /// <param name="isrc"></param>
        /// <param name="storefront"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<MusicVideoResponse> GetMultipleCatalogMusicVideosByIsrc(string isrc, string storefront, IReadOnlyCollection<string> ids = null, IReadOnlyCollection<MusicVideoRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(isrc))
                throw new ArgumentNullException(nameof(isrc));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>()
            {
                {"filter[isrc]", isrc},
            };

            return await GetMultipleCatalogResources<MusicVideoResponse, MusicVideoRelationship>(CatalogResource.MusicVideos, ids, storefront, include, queryString)
                .ConfigureAwait(false);
        }

        #endregion

        #region Playlists

        /// <summary>
        /// Fetch a playlist by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_playlist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<PlaylistResponse> GetCatalogPlaylist(string id, string storefront, IReadOnlyCollection<PlaylistRelationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<PlaylistResponse, PlaylistRelationship>(CatalogResource.Playlists, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a playlist's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_playlist_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<PlaylistResponse> GetCatalogPlaylistRelationship(string id, string storefront, PlaylistRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<PlaylistResponse, PlaylistRelationship>(CatalogResource.Playlists, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more playlists by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_playlists
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<PlaylistResponse> GetMultipleCatalogPlaylists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<PlaylistRelationship> include = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<PlaylistResponse, PlaylistRelationship>(CatalogResource.Playlists, ids, storefront, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region Songs

        /// <summary>
        /// Fetch a song by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_song
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<SongResponse> GetCatalogSong(string id, string storefront, IReadOnlyCollection<SongRelationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<SongResponse, SongRelationship>(CatalogResource.Songs, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a song's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_song_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<SongResponse> GetCatalogSongRelationship(string id, string storefront, SongRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<SongResponse, SongRelationship>(CatalogResource.Songs, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more songs by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_songs_by_id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="isrc"></param>
        /// <returns></returns>
        public async Task<SongResponse> GetMultipleCatalogSongs(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<SongRelationship> include = null, string isrc = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(isrc))
                queryString.Add("filter[isrc]", isrc);

            return await GetMultipleCatalogResources<SongResponse, SongRelationship>(CatalogResource.Songs, ids, storefront, include, queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more songs by using their ISRC values.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_songs_by_isrc
        /// </summary>
        /// <param name="isrc"></param>
        /// <param name="storefront"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<SongResponse> GetMultipleCatalogSongsByIsrc(string isrc, string storefront, IReadOnlyCollection<string> ids = null, IReadOnlyCollection<SongRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(isrc))
                throw new ArgumentNullException(nameof(isrc));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>()
            {
                {"filter[isrc]", isrc},
            };

            return await GetMultipleCatalogResources<SongResponse, SongRelationship>(CatalogResource.Songs, ids, storefront, include, queryString)
                .ConfigureAwait(false);
        }

        #endregion

        #region Stations

        /// <summary>
        /// Fetch a station by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_station
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<StationResponse> GetCatalogStation(string id, string storefront)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<StationResponse>(CatalogResource.Stations, id, storefront)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more stations by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_stations
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        public async Task<StationResponse> GetMultipleCatalogStations(IReadOnlyCollection<string> ids, string storefront)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>
            {
                {"ids", string.Join(",", ids)}
            };

            return await GetMultipleCatalogResources<StationResponse>(CatalogResource.Stations, storefront, queryString)
                .ConfigureAwait(false);
        }

        #endregion

        #region Artists

        /// <summary>
        /// Fetch an artist by using the artist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_artist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<ArtistResponse> GetCatalogArtist(string id, string storefront, IReadOnlyCollection<ArtistRelationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<ArtistResponse, ArtistRelationship>(CatalogResource.Artists, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch an artist's relationship by using the artist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_artist_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<ArtistResponse> GetCatalogArtistRelationship(string id, string storefront, ArtistRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<ArtistResponse, ArtistRelationship>(CatalogResource.Artists, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more artists by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_artists
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<ArtistResponse> GetMultipleCatalogArtists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ArtistRelationship> include = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<ArtistResponse, ArtistRelationship>(CatalogResource.Artists, ids, storefront, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region Curators

        /// <summary>
        /// Fetch a curator by using the curator's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_curator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<CuratorResponse> GetCatalogCurator(string id, string storefront, IReadOnlyCollection<CuratorRelationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<CuratorResponse, CuratorRelationship>(CatalogResource.Curators, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a curator's relationship by using the curator's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_curator_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<CuratorResponse> GetCatalogCuratorRelationship(string id, string storefront, CuratorRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<CuratorResponse, CuratorRelationship>(CatalogResource.Curators, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more curators by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_curators
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<CuratorResponse> GetMultipleCatalogCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<CuratorRelationship> include = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<CuratorResponse, CuratorRelationship>(CatalogResource.Curators, ids, storefront, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region Activities

        /// <summary>
        /// Fetch an activity by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_activity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<ActivityResponse> GetCatalogActivity(string id, string storefront, IReadOnlyCollection<ActivityRelationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<ActivityResponse, ActivityRelationship>(CatalogResource.Activities, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch an activity's relationship by using its identifier.
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

            return await GetCatalogResourceRelationship<ActivityResponse, ActivityRelationship>(CatalogResource.Activities, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more activities by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_activities
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<ActivityResponse> GetMultipleCatalogActivities(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ActivityRelationship> include = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<ActivityResponse, ActivityRelationship>(CatalogResource.Activities, ids, storefront, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region Apple Curators

        /// <summary>
        /// Fetch an Apple curator by using the curator's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_apple_curator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        public async Task<AppleCuratorResponse> GetCatalogAppleCurator(string id, string storefront, IReadOnlyCollection<AppleCuratorRelationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<AppleCuratorResponse, AppleCuratorRelationship>(CatalogResource.AppleCurators, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch an Apple curator's relationship by using the curator's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_apple_curator_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<AppleCuratorResponse> GetCatalogAppleCuratorRelationship(string id, string storefront, AppleCuratorRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResourceRelationship<AppleCuratorResponse, AppleCuratorRelationship>(CatalogResource.AppleCurators, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more Apple curators by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_apple_curators
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<AppleCuratorResponse> GetMultipleCatalogAppleCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AppleCuratorRelationship> include = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogResources<AppleCuratorResponse, AppleCuratorRelationship>(CatalogResource.AppleCurators, ids, storefront, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region Genres

        /// <summary>
        /// Fetch a genre by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_genre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        public async Task<GenreResponse> GetCatalogGenre(string id, string storefront)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogResource<GenreResponse>(CatalogResource.Genres, id, storefront)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more genres.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_genres
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        public async Task<GenreResponse> GetMultipleCatalogGenres(IReadOnlyCollection<string> ids, string storefront)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            var queryString = new Dictionary<string, string>
            {
                {"ids", string.Join(",", ids)}
            };

            return await GetMultipleCatalogResources<GenreResponse>(CatalogResource.Genres, storefront, queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all genres for the current top charts.
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_top_charts_genres
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<GenreResponse> GetCatalogTopChartsGenres(string storefront, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await Get<GenreResponse>($"{BaseCatalogRequestUri}/{storefront}/{CatalogResource.Genres.GetValue()}", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Library albums

        /// <summary>
        /// Fetch a library album by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_album
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryAlbumResponse> GetLibraryAlbum(string userToken, string id, IReadOnlyCollection<LibraryAlbumRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResource<LibraryAlbumResponse, LibraryAlbumRelationship>(LibraryResource.Albums, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library album's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_album_s_relationship_directly_by_name
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="relationship"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<LibraryAlbumResponse> GetLibraryAlbumRelationship(string userToken, string id, LibraryAlbumRelationship relationship, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResourceRelationship<LibraryAlbumResponse, LibraryAlbumRelationship>(LibraryResource.Albums, id, relationship, pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more library albums by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_albums
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryAlbumResponse> GetMultipleLibraryAlbums(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryAlbumRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            SetUserTokenHeader(userToken);

            return await GetMultipleLibraryResources<LibraryAlbumResponse, LibraryAlbumRelationship>(LibraryResource.Albums, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the library albums in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_albums
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<LibraryAlbumResponse> GetAllLibraryAlbums(string userToken, IReadOnlyCollection<LibraryAlbumRelationship> include = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await GetAllLibraryResources<LibraryAlbumResponse, LibraryAlbumRelationship>(LibraryResource.Albums, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Library artists

        /// <summary>
        /// Fetch a library artist by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_artist
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryArtistResponse> GetLibraryArtist(string userToken, string id, IReadOnlyCollection<LibraryArtistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResource<LibraryArtistResponse, LibraryArtistRelationship>(LibraryResource.Artists, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library artist's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_artist_s_relationship_directly_by_name
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<LibraryArtistResponse> GetLibraryArtistRelationship(string userToken, string id, LibraryArtistRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResourceRelationship<LibraryArtistResponse, LibraryArtistRelationship>(LibraryResource.Artists, id, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more library artists by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_artists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryArtistResponse> GetMultipleLibraryArtists(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryArtistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            SetUserTokenHeader(userToken);

            return await GetMultipleLibraryResources<LibraryArtistResponse, LibraryArtistRelationship>(LibraryResource.Artists, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the library artists in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_artists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<LibraryArtistResponse> GetAllLibraryArtists(string userToken, IReadOnlyCollection<LibraryArtistRelationship> include = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await GetAllLibraryResources<LibraryArtistResponse, LibraryArtistRelationship>(LibraryResource.Artists, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Library music videos

        /// <summary>
        /// Fetch a library music video by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_music_video
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryMusicVideoResponse> GetLibraryMusicVideo(string userToken, string id, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResource<LibraryMusicVideoResponse, LibraryMusicVideoRelationship>(LibraryResource.MusicVideos, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library music video's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_music_video_s_relationship_directly_by_name
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<LibraryMusicVideoResponse> GetLibraryMusicVideoRelationship(string userToken, string id, LibraryMusicVideoRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResourceRelationship<LibraryMusicVideoResponse, LibraryMusicVideoRelationship>(LibraryResource.MusicVideos, id, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more library music videos by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_music_videos
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryMusicVideoResponse> GetMultipleLibraryMusicVideos(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            SetUserTokenHeader(userToken);

            return await GetMultipleLibraryResources<LibraryMusicVideoResponse, LibraryMusicVideoRelationship>(LibraryResource.MusicVideos, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the library music videos in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_music_videos
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<LibraryMusicVideoResponse> GetAllLibraryMusicVideos(string userToken, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await GetAllLibraryResources<LibraryMusicVideoResponse, LibraryMusicVideoRelationship>(LibraryResource.MusicVideos, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Library playlists

        /// <summary>
        /// Fetch a library playlist by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_playlist
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryPlaylistResponse> GetLibraryPlaylist(string userToken, string id, IReadOnlyCollection<LibraryPlaylistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResource<LibraryPlaylistResponse, LibraryPlaylistRelationship>(LibraryResource.Playlists, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library playlist's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_playlist_s_relationship_directly_by_name
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<LibraryPlaylistResponse> GetLibraryPlaylistRelationship(string userToken, string id, LibraryPlaylistRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResourceRelationship<LibraryPlaylistResponse, LibraryPlaylistRelationship>(LibraryResource.Playlists, id, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more library playlists by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_playlists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibraryPlaylistResponse> GetMultipleLibraryPlaylists(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryPlaylistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            SetUserTokenHeader(userToken);

            return await GetMultipleLibraryResources<LibraryPlaylistResponse, LibraryPlaylistRelationship>(LibraryResource.Playlists, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the library playlists in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_playlists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<LibraryPlaylistResponse> GetAllLibraryPlaylists(string userToken, IReadOnlyCollection<LibraryPlaylistRelationship> include = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await GetAllLibraryResources<LibraryPlaylistResponse, LibraryPlaylistRelationship>(LibraryResource.Playlists, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Library songs

        /// <summary>
        /// Fetch a library song by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_song
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibrarySongResponse> GetLibrarySong(string userToken, string id, IReadOnlyCollection<LibrarySongRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResource<LibrarySongResponse, LibrarySongRelationship>(LibraryResource.Songs, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library song's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_song_s_relationship_directly_by_name
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<LibrarySongResponse> GetLibrarySongRelationship(string userToken, string id, LibrarySongRelationship relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await GetLibraryResourceRelationship<LibrarySongResponse, LibrarySongRelationship>(LibraryResource.Songs, id, relationship, limit)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library song by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_song
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<LibrarySongResponse> GetMultipleLibrarySongs(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibrarySongRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            SetUserTokenHeader(userToken);

            return await GetMultipleLibraryResources<LibrarySongResponse, LibrarySongRelationship>(LibraryResource.Songs, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the library songs in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_songs
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<LibrarySongResponse> GetAllLibrarySongs(string userToken, IReadOnlyCollection<LibrarySongRelationship> include = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await GetAllLibraryResources<LibrarySongResponse, LibrarySongRelationship>(LibraryResource.Songs, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Fetch a catalog resource by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="catalogResource"></param>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private async Task<TResponse> GetCatalogResource<TResponse>(CatalogResource catalogResource, string id, string storefront, Dictionary<string, string> queryString = null)
        {
            return await Get<TResponse>($"{BaseCatalogRequestUri}/{storefront}/{catalogResource.GetValue()}/{id}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a catalog resource by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="catalogResource"></param>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        private async Task<TResponse> GetCatalogResource<TResponse, TRelationshipEnum>(CatalogResource catalogResource, string id, string storefront, IReadOnlyCollection<TRelationshipEnum> relationshipsToInclude = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();
            if (relationshipsToInclude != null && relationshipsToInclude.Any())
                queryString.Add("include", string.Join(",", relationshipsToInclude.Select(x => x.GetValue())));

            return await GetCatalogResource<TResponse>(catalogResource, id, storefront, queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library resource by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="libraryResource"></param>
        /// <param name="id"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        private async Task<TResponse> GetLibraryResource<TResponse, TRelationshipEnum>(LibraryResource libraryResource, string id, IReadOnlyCollection<TRelationshipEnum> relationshipsToInclude = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();
            if (relationshipsToInclude != null && relationshipsToInclude.Any())
                queryString.Add("include", string.Join(",", relationshipsToInclude.Select(x => x.GetValue())));

            return await Get<TResponse>($"{BaseLibraryRequestUri}/{libraryResource.GetValue()}/{id}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a catalog resource's relationship by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="catalogResource"></param>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private async Task<TResponse> GetCatalogResourceRelationship<TResponse, TRelationshipEnum>(CatalogResource catalogResource, string id, string storefront, TRelationshipEnum relationship, int? limit = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();
            if (limit.HasValue)
                queryString.Add("limit", limit.Value.ToString());

            return await Get<TResponse>($"{BaseCatalogRequestUri}/{storefront}/{catalogResource.GetValue()}/{id}/{relationship.GetValue()}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library resource's relationship by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="libraryResource"></param>
        /// <param name="id"></param>
        /// <param name="relationship"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        private async Task<TResponse> GetLibraryResourceRelationship<TResponse, TRelationshipEnum>(LibraryResource libraryResource, string id, TRelationshipEnum relationship, PageOptions pageOptions = null)
            where TRelationshipEnum : IConvertible
        {
            return await Get<TResponse>($"{BaseLibraryRequestUri}/{libraryResource.GetValue()}/{id}/{relationship.GetValue()}", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a library resource's relationship by using its identifier.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="libraryResource"></param>
        /// <param name="id"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private async Task<TResponse> GetLibraryResourceRelationship<TResponse, TRelationshipEnum>(LibraryResource libraryResource, string id, TRelationshipEnum relationship, int? limit = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();
            if (limit.HasValue)
                queryString.Add("limit", limit.Value.ToString());

            return await Get<TResponse>($"{BaseLibraryRequestUri}/{libraryResource.GetValue()}/{id}/{relationship.GetValue()}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more catalog resources by using their identifiers.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="catalogResource"></param>
        /// <param name="storefront"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private async Task<TResponse> GetMultipleCatalogResources<TResponse>(CatalogResource catalogResource, string storefront, IDictionary<string, string> queryString = null)
        {
            return await Get<TResponse>($"{BaseCatalogRequestUri}/{storefront}/{catalogResource.GetValue()}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more catalog resources by using their identifiers.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="catalogResource"></param>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="additionalQuerystringParams"></param>
        /// <returns></returns>
        private async Task<TResponse> GetMultipleCatalogResources<TResponse, TRelationshipEnum>(CatalogResource catalogResource, IEnumerable<string> ids, string storefront, IReadOnlyCollection<TRelationshipEnum> include = null, IDictionary<string, string> additionalQuerystringParams = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();

            if (ids != null && ids.Any())
                queryString.Add("ids", string.Join(",", ids));

            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            if (additionalQuerystringParams != null && additionalQuerystringParams.Any())
                queryString.Merge(additionalQuerystringParams);

            return await GetMultipleCatalogResources<TResponse>(catalogResource, storefront, queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch one or more library resources by using their identifiers.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="libraryResource"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        private async Task<TResponse> GetMultipleLibraryResources<TResponse, TRelationshipEnum>(LibraryResource libraryResource, IEnumerable<string> ids, IReadOnlyCollection<TRelationshipEnum> include = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();

            if (ids != null && ids.Any())
                queryString.Add("ids", string.Join(",", ids));

            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            return await Get<TResponse>($"{BaseLibraryRequestUri}/{libraryResource.GetValue()}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all library resources.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="libraryResource"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        private async Task<TResponse> GetAllLibraryResources<TResponse, TRelationshipEnum>(LibraryResource libraryResource, IReadOnlyCollection<TRelationshipEnum> include = null, PageOptions pageOptions = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();

            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            return await Get<TResponse>($"{BaseLibraryRequestUri}/{libraryResource.GetValue()}", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion
    }
}