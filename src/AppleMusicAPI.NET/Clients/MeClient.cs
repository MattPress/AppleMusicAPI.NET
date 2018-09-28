using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class MeClient : BaseClient, IMeClient
    {
        private const string BaseRequestUri = "me";

        public MeClient(HttpClient client, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(client, jsonSerializer, jwtProvider)
        {
        }

        #region me/history/heavy-rotation

        /// <summary>
        /// Fetch the resources in heavy rotation for the user.
        /// me/history/heavy-rotation
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

            return await Get<HistoryResponse>($"{BaseRequestUri}/history/heavy-rotation", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library

        /// <summary>
        /// Add a catalog resource to a user’s iCloud Music Library.
        /// POST me/library
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

        #region me/library/albums/{id}

        /// <summary>
        /// Fetch a library album by using its identifier.
        /// me/library/albums/{id}
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

            return await GetLibraryResource<LibraryAlbumResponse, LibraryAlbumRelationship>(ResourceType.Albums, id, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/albums/{id}/{relationship}

        /// <summary>
        /// Fetch a library album's relationship by using its identifier.
        /// me/library/albums/{id}/{relationship}
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

            return await GetLibraryResourceRelationship<LibraryAlbumResponse, LibraryAlbumRelationship>(ResourceType.Albums, id, relationship, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/albums

        /// <summary>
        /// Fetch one or more library albums by using their identifiers.
        /// me/library/albums
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

            return await GetMultipleLibraryResources<LibraryAlbumResponse, LibraryAlbumRelationship>(ResourceType.Albums, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the library albums in alphabetical order.
        /// me/library/albums
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

            return await GetAllLibraryResources<LibraryAlbumResponse, LibraryAlbumRelationship>(ResourceType.Albums, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/artists/{id}

        /// <summary>
        /// Fetch a library artist by using its identifier.
        /// me/library/artists/{id}
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

            return await GetLibraryResource<LibraryArtistResponse, LibraryArtistRelationship>(ResourceType.Artists, id, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/artists/{id}/{relationship}

        /// <summary>
        /// Fetch a library artist's relationship by using its identifier.
        /// me/library/artists/{id}/{relationship}
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

            return await GetLibraryResourceRelationship<LibraryArtistResponse, LibraryArtistRelationship>(ResourceType.Artists, id, relationship, limit)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/artists

        /// <summary>
        /// Fetch one or more library artists by using their identifiers.
        /// me/library/artists
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

            return await GetMultipleLibraryResources<LibraryArtistResponse, LibraryArtistRelationship>(ResourceType.Artists, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the library artists in alphabetical order.
        /// me/library/artists
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

            return await GetAllLibraryResources<LibraryArtistResponse, LibraryArtistRelationship>(ResourceType.Artists, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/music-videos/{id}

        /// <summary>
        /// Fetch a library music video by using its identifier.
        /// me/library/music-videos/{id}
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

            return await GetLibraryResource<LibraryMusicVideoResponse, LibraryMusicVideoRelationship>(ResourceType.MusicVideos, id, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/music-videos/{id}/{relationship}

        /// <summary>
        /// Fetch a library music video's relationship by using its identifier.
        /// me/library/music-videos/{id}/{relationship}
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

            return await GetLibraryResourceRelationship<LibraryMusicVideoResponse, LibraryMusicVideoRelationship>(ResourceType.MusicVideos, id, relationship, limit)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/music-videos

        /// <summary>
        /// Fetch one or more library music videos by using their identifiers.
        /// me/library/music-videos
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

            return await GetMultipleLibraryResources<LibraryMusicVideoResponse, LibraryMusicVideoRelationship>(ResourceType.MusicVideos, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch all the library music videos in alphabetical order.
        /// me/library/music-videos
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

            return await GetAllLibraryResources<LibraryMusicVideoResponse, LibraryMusicVideoRelationship>(ResourceType.MusicVideos, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/playlists/{id}

        /// <summary>
        /// Fetch a library playlist by using its identifier.
        /// me/library/playlists/{id}
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

            return await GetLibraryResource<LibraryPlaylistResponse, LibraryPlaylistRelationship>(ResourceType.Playlists, id, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/playlists/{id}/{relationship}

        /// <summary>
        /// Fetch a library playlist's relationship by using its identifier.
        /// me/library/playlists/{id}/{relationship}
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

            return await GetLibraryResourceRelationship<LibraryPlaylistResponse, LibraryPlaylistRelationship>(ResourceType.Playlists, id, relationship, limit)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/playlists

        /// <summary>
        /// Fetch one or more library playlists by using their identifiers.
        /// me/library/playlists
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

            return await GetMultipleLibraryResources<LibraryPlaylistResponse, LibraryPlaylistRelationship>(ResourceType.Playlists, ids, include)
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

            return await GetAllLibraryResources<LibraryPlaylistResponse, LibraryPlaylistRelationship>(ResourceType.Playlists, include, pageOptions)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new playlist in a user’s library.
        /// POST me/library/playlists
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

        #region me/library/recently-added

        /// <summary>
        /// Fetch the resources recently added to the library.
        /// me/library/recently-added
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_added_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        public async Task<RecentlyAddedResponse> GetRecentlyAddedResources(string userToken, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            return await Get<RecentlyAddedResponse>($"{BaseRequestUri}/library/recently-added", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/search

        /// <summary>
        /// Search the library by using a query.
        /// me/library/search
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

        #region me/library/songs/{id}

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

            return await GetLibraryResource<LibrarySongResponse, LibrarySongRelationship>(ResourceType.Songs, id, include)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/songs/{id}/{relationship}

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

            return await GetLibraryResourceRelationship<LibrarySongResponse, LibrarySongRelationship>(ResourceType.Songs, id, relationship, limit)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/library/songs

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

            return await GetMultipleLibraryResources<LibrarySongResponse, LibrarySongRelationship>(ResourceType.Songs, ids, include)
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

            return await GetAllLibraryResources<LibrarySongResponse, LibrarySongRelationship>(ResourceType.Songs, include, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/ratings/albums

        /// <summary>
        /// Fetch a user’s rating for an album by using the user's identifier.
        /// me/ratings/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetAlbumRating(string userToken, string id, IReadOnlyCollection<AlbumRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetResourceRating(userToken, ResourceType.Albums, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more albums by using the albums' identifiers.
        /// me/ratings/albums
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_album_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMultipleAlbumRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<AlbumRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleResourceRatings(userToken, ResourceType.Albums, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s album rating by using the album's identifier.
        /// me/ratings/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RatingResponse> AddAlbumRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddResourceRating(userToken, ResourceType.Albums, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s album rating by using the album's identifier.
        /// me/ratings/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> DeleteAlbumRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteResourceRating(userToken, ResourceType.Albums, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/ratings/music-videos

        /// <summary>
        /// Fetch a user’s rating for a music video by using the video's identifier.
        /// me/ratings/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMusicVideoRating(string userToken, string id, IReadOnlyCollection<MusicVideoRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetResourceRating(userToken, ResourceType.MusicVideos, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more music videos by using the music videos' identifiers.
        /// me/ratings/music-videos
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_music_video_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMultipleMusicVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<MusicVideoRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleResourceRatings(userToken, ResourceType.MusicVideos, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s music video rating by using the music video's identifier.
        /// me/ratings/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RatingResponse> AddMusicVideoRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddResourceRating(userToken, ResourceType.MusicVideos, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s music video rating by using the music video's identifier.
        /// me/ratings/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> DeleteMusicVideoRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteResourceRating(userToken, ResourceType.MusicVideos, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/ratings/playlists

        /// <summary>
        /// Fetch a user’s rating for a playlist by using the playlist's identifier.
        /// me/ratings/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetPlaylistRating(string userToken, string id, IReadOnlyCollection<PlaylistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetResourceRating(userToken, ResourceType.Playlists, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more playlists by using the playlists' identifiers.
        /// me/ratings/playlists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_playlist_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMultiplePlaylistRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<PlaylistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleResourceRatings(userToken, ResourceType.Playlists, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s playlist rating by using the playlist's identifier.
        /// me/ratings/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RatingResponse> AddPlaylistRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddResourceRating(userToken, ResourceType.Playlists, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s playlist rating by using the playlist's identifier.
        /// me/ratings/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> DeletePlaylistRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteResourceRating(userToken, ResourceType.Playlists, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/ratings/songs

        /// <summary>
        /// Fetch a user’s rating for a song by using the song's identifier.
        /// me/ratings/songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetSongRating(string userToken, string id, IReadOnlyCollection<SongRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetResourceRating(userToken, ResourceType.Songs, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more songs by using the songs' identifiers.
        /// me/ratings/songs
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_song_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMultipleSongRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<SongRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleResourceRatings(userToken, ResourceType.Songs, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s song rating by using the song's identifier.
        /// me/ratings/songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RatingResponse> AddSongRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddResourceRating(userToken, ResourceType.Songs, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s song rating by using the song's identifier.
        /// me/ratings/songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> DeleteSongRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteResourceRating(userToken, ResourceType.Songs, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/ratings/stations

        /// <summary>
        /// Fetch a user’s rating for a station by using the station's identifier.
        /// me/ratings/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetStationRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetResourceRating(userToken, ResourceType.Stations, id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more stations by using the stations' identifiers.
        /// me/ratings/stations
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_station_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMultipleStationRatings(string userToken, IReadOnlyCollection<string> ids)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleResourceRatings(userToken, ResourceType.Stations, ids)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s station rating by using the station's identifier.
        /// me/ratings/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RatingResponse> AddStationRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddResourceRating(userToken, ResourceType.Stations, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s station rating by using the station's identifier.
        /// me/ratings/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> DeleteStationRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteResourceRating(userToken, ResourceType.Stations, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/ratings/library-music-videos

        /// <summary>
        /// Fetch a user’s rating for a library music video by using the music video's library identifier.
        /// me/ratings/library-music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetLibraryMusicVideoRating(string userToken, string id, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetResourceRating(userToken, LibraryResource.MusicVideos, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more library music videos by using the library music videos' identifiers.
        /// me/ratings/library-music-videos
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_music_video_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMultipleLibraryMusicVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleResourceRatings(userToken, LibraryResource.MusicVideos, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s library music video rating by using the library music video's identifier.
        /// me/ratings/library-music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RatingResponse> AddLibraryMusicVideoRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddResourceRating(userToken, LibraryResource.MusicVideos, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s library music video rating by using the library music video's identifier.
        /// me/ratings/library-music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> DeleteLibraryMusicVideoRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteResourceRating(userToken, LibraryResource.MusicVideos, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/ratings/library-playlists

        /// <summary>
        /// Fetch a user’s rating for a library playlist by using the playlist's library identifier.
        /// me/ratings/library-playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetLibraryPlaylistRating(string userToken, string id, IReadOnlyCollection<LibraryPlaylistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetResourceRating(userToken, LibraryResource.Playlists, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more library playlists by using the library playlists' identifiers.
        /// me/ratings/library-playlists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_playlist_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMultipleLibraryPlaylistRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryPlaylistRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleResourceRatings(userToken, LibraryResource.Playlists, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s library playlist rating by using the library playlist's identifier.
        /// me/ratings/library-playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RatingResponse> AddLibraryPlaylistRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddResourceRating(userToken, LibraryResource.Playlists, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s library playlist rating by using the library playlist's identifier.
        /// me/ratings/library-playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> DeleteLibraryPlaylistRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteResourceRating(userToken, LibraryResource.Playlists, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/ratings/library-songs

        /// <summary>
        /// Fetch a user’s rating for a library song by using the song's library identifier.
        /// me/ratings/library-songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetLibrarySongRating(string userToken, string id, IReadOnlyCollection<LibrarySongRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await GetResourceRating(userToken, LibraryResource.Songs, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more library songs by using the library songs' identifiers.
        /// me/ratings/library-songs
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_songs_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<RatingResponse> GetMultipleLibrarySongRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibrarySongRelationship> include = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            return await GetMultipleResourceRatings(userToken, LibraryResource.Songs, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s library song rating by using the library song's identifier.
        /// me/ratings/library-songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RatingResponse> AddLibrarySongRating(string userToken, string id, RatingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await AddResourceRating(userToken, LibraryResource.Songs, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s library song rating by using the library song's identifier.
        /// me/ratings/library-songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseRoot> DeleteLibrarySongRating(string userToken, string id)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            return await DeleteResourceRating(userToken, LibraryResource.Songs, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/recent/played

        /// <summary>
        /// Fetch the recently played resources for the user.
        /// me/recent/played
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

            return await Get<HistoryResponse>($"{BaseRequestUri}/recent/played", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/recent/radio-stations

        /// <summary>
        /// Fetch recently played radio stations for the user.
        /// me/recent/radio-stations
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

            return await Get<HistoryResponse>($"{BaseRequestUri}/recent/radio-stations", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        #endregion

        #region me/recommendations

        /// <summary>
        /// Fetch a recommendation by using its identifier.
        /// me/recommendations/{id}
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

        /// <summary>
        /// Fetch one or more recommendations by using their identifiers.
        /// me/recommendations
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
        /// me/recommendations
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

        #region me/storefront

        /// <summary>
        /// Fetch a user’s storefront.
        /// me/storefront
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

        #region Private Methods

        /// <summary>
        /// Fetch a resource rating.
        /// For resources without relationships.
        /// </summary>
        /// <typeparam name="TResourceEnum"></typeparam>
        /// <param name="userToken"></param>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<RatingResponse> GetResourceRating<TResourceEnum>(string userToken, TResourceEnum resource, string id)
            where TResourceEnum : IConvertible
        {
            SetUserTokenHeader(userToken);

            return await Get<RatingResponse>($"{BaseRequestUri}/ratings/{resource.GetValue()}/{id}")
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch a resource rating.
        /// </summary>
        /// <typeparam name="TResourceEnum"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="userToken"></param>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        private async Task<RatingResponse> GetResourceRating<TResourceEnum, TRelationshipEnum>(string userToken, TResourceEnum resource, string id, IReadOnlyCollection<TRelationshipEnum> include)
            where TResourceEnum : IConvertible
            where TRelationshipEnum : IConvertible
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();
            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            return await Get<RatingResponse>($"{BaseRequestUri}/ratings/{resource.GetValue()}/{id}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch multiple resource ratings.
        /// For resources without relationships.
        /// </summary>
        /// <typeparam name="TResourceEnum"></typeparam>
        /// <param name="userToken"></param>
        /// <param name="resource"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        private async Task<RatingResponse> GetMultipleResourceRatings<TResourceEnum>(string userToken, TResourceEnum resource, IReadOnlyCollection<string> ids)
            where TResourceEnum : IConvertible
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>
            {
                { "ids", string.Join(",", ids) }
            };

            return await Get<RatingResponse>($"{BaseRequestUri}/ratings/{resource.GetValue()}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch multiple resource ratings.
        /// </summary>
        /// <typeparam name="TResourceEnum"></typeparam>
        /// <typeparam name="TRelationshipEnum"></typeparam>
        /// <param name="userToken"></param>
        /// <param name="resource"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        private async Task<RatingResponse> GetMultipleResourceRatings<TResourceEnum, TRelationshipEnum>(string userToken, TResourceEnum resource, IReadOnlyCollection<string> ids, IReadOnlyCollection<TRelationshipEnum> include = null)
            where TResourceEnum : IConvertible
            where TRelationshipEnum : IConvertible
        {
            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>
            {
                { "ids", string.Join(",", ids) }
            };

            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            return await Get<RatingResponse>($"{BaseRequestUri}/ratings/{resource.GetValue()}", queryString)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a resource rating.
        /// </summary>
        /// <typeparam name="TResourceEnum"></typeparam>
        /// <param name="userToken"></param>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<RatingResponse> AddResourceRating<TResourceEnum>(string userToken, TResourceEnum resource, string id, RatingRequest request)
            where TResourceEnum : IConvertible
        {
            SetUserTokenHeader(userToken);

            return await Put<RatingResponse, RatingRequest>($"{BaseRequestUri}/ratings/{resource.GetValue()}/{id}", request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a resource rating.
        /// </summary>
        /// <typeparam name="TResourceEnum"></typeparam>
        /// <param name="userToken"></param>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<ResponseRoot> DeleteResourceRating<TResourceEnum>(string userToken, TResourceEnum resource, string id)
            where TResourceEnum : IConvertible
        {
            SetUserTokenHeader(userToken);

            return await Delete($"{BaseRequestUri}/ratings/{resource.GetValue()}/{id}")
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
        private async Task<TResponse> GetLibraryResource<TResponse, TRelationshipEnum>(ResourceType libraryResource, string id, IReadOnlyCollection<TRelationshipEnum> relationshipsToInclude = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();
            if (relationshipsToInclude != null && relationshipsToInclude.Any())
                queryString.Add("include", string.Join(",", relationshipsToInclude.Select(x => x.GetValue())));

            return await Get<TResponse>($"{BaseRequestUri}/library/{libraryResource.GetValue()}/{id}", queryString)
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
        private async Task<TResponse> GetLibraryResourceRelationship<TResponse, TRelationshipEnum>(ResourceType libraryResource, string id, TRelationshipEnum relationship, PageOptions pageOptions = null)
            where TRelationshipEnum : IConvertible
        {
            return await Get<TResponse>($"{BaseRequestUri}/library/{libraryResource.GetValue()}/{id}/{relationship.GetValue()}", pageOptions: pageOptions)
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
        private async Task<TResponse> GetLibraryResourceRelationship<TResponse, TRelationshipEnum>(ResourceType libraryResource, string id, TRelationshipEnum relationship, int? limit = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();
            if (limit.HasValue)
                queryString.Add("limit", limit.Value.ToString());

            return await Get<TResponse>($"{BaseRequestUri}/library/{libraryResource.GetValue()}/{id}/{relationship.GetValue()}", queryString)
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
        private async Task<TResponse> GetMultipleLibraryResources<TResponse, TRelationshipEnum>(ResourceType libraryResource, IEnumerable<string> ids, IReadOnlyCollection<TRelationshipEnum> include = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();

            if (ids != null && ids.Any())
                queryString.Add("ids", string.Join(",", ids));

            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            return await Get<TResponse>($"{BaseRequestUri}/library/{libraryResource.GetValue()}", queryString)
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
        private async Task<TResponse> GetAllLibraryResources<TResponse, TRelationshipEnum>(ResourceType libraryResource, IReadOnlyCollection<TRelationshipEnum> include = null, PageOptions pageOptions = null)
            where TRelationshipEnum : IConvertible
        {
            var queryString = new Dictionary<string, string>();

            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.GetValue())));

            return await Get<TResponse>($"{BaseRequestUri}/library/{libraryResource.GetValue()}", queryString, pageOptions)
                .ConfigureAwait(false);
        }

        #endregion
    }
}
