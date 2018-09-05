using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    /// <summary>
    /// Ratings client.
    /// </summary>
    public class RatingsClient : BaseClient, IRatingsClient
    {
        private const string BaseRequestUri = "me/ratings";

        public RatingsClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        #region Catalog Album Ratings

        /// <summary>
        /// Fetch a user’s rating for an album by using the user's identifier.
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

            return await GetResourceRating(userToken, CatalogResource.Albums, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more albums by using the albums' identifiers.
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

            return await GetMultipleResourceRatings(userToken, CatalogResource.Albums, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s album rating by using the album's identifier.
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

            return await AddResourceRating(userToken, CatalogResource.Albums, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s album rating by using the album's identifier.
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

            return await DeleteResourceRating(userToken, CatalogResource.Albums, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region Catalog Music video Ratings

        /// <summary>
        /// Fetch a user’s rating for a music video by using the video's identifier.
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

            return await GetResourceRating(userToken, CatalogResource.MusicVideos, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more music videos by using the music videos' identifiers.
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

            return await GetMultipleResourceRatings(userToken, CatalogResource.MusicVideos, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s music video rating by using the music video's identifier.
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

            return await AddResourceRating(userToken, CatalogResource.MusicVideos, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s music video rating by using the music video's identifier.
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

            return await DeleteResourceRating(userToken, CatalogResource.MusicVideos, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region Catalog Playlist Ratings

        /// <summary>
        /// Fetch a user’s rating for a playlist by using the playlist's identifier.
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

            return await GetResourceRating(userToken, CatalogResource.Playlists, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more playlists by using the playlists' identifiers.
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

            return await GetMultipleResourceRatings(userToken, CatalogResource.Playlists, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s playlist rating by using the playlist's identifier.
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

            return await AddResourceRating(userToken, CatalogResource.Playlists, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s playlist rating by using the playlist's identifier.
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

            return await DeleteResourceRating(userToken, CatalogResource.Playlists, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region Catalog Song Ratings

        /// <summary>
        /// Fetch a user’s rating for a song by using the song's identifier.
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

            return await GetResourceRating(userToken, CatalogResource.Songs, id, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more songs by using the songs' identifiers.
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

            return await GetMultipleResourceRatings(userToken, CatalogResource.Songs, ids, include)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s song rating by using the song's identifier.
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

            return await AddResourceRating(userToken, CatalogResource.Songs, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s song rating by using the song's identifier.
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

            return await DeleteResourceRating(userToken, CatalogResource.Songs, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region Catalog Station Ratings

        /// <summary>
        /// Fetch a user’s rating for a station by using the station's identifier.
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

            return await GetResourceRating(userToken, CatalogResource.Stations, id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch the user’s ratings for one or more stations by using the stations' identifiers.
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

            return await GetMultipleResourceRatings(userToken, CatalogResource.Stations, ids)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Add a user’s station rating by using the station's identifier.
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

            return await AddResourceRating(userToken, CatalogResource.Stations, id, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove a user’s station rating by using the station's identifier.
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

            return await DeleteResourceRating(userToken, CatalogResource.Stations, id)
                .ConfigureAwait(false);
        }

        #endregion

        #region Library Music Video Ratings

        /// <summary>
        /// Fetch a user’s rating for a library music video by using the music video's library identifier.
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

        #region Library Playlist Ratings

        /// <summary>
        /// Fetch a user’s rating for a library playlist by using the playlist's library identifier.
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

        #region Library Song Ratings

        /// <summary>
        /// Fetch a user’s rating for a library song by using the song's library identifier.
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

            return await Get<RatingResponse>($"{BaseRequestUri}/{resource.GetValue()}/{id}")
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

            return await Get<RatingResponse>($"{BaseRequestUri}/{resource.GetValue()}/{id}", queryString)
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

            return await Get<RatingResponse>($"{BaseRequestUri}/{resource.GetValue()}", queryString)
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

            return await Get<RatingResponse>($"{BaseRequestUri}/{resource.GetValue()}", queryString)
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

            return await Put<RatingResponse, RatingRequest>($"{BaseRequestUri}/{resource.GetValue()}/{id}", request)
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

            return await Delete($"{BaseRequestUri}/{resource.GetValue()}/{id}")
                .ConfigureAwait(false);
        }

        #endregion
    }
}
