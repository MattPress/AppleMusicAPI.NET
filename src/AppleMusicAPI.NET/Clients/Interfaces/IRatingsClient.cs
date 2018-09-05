using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    /// <summary>
    /// Ratings client contract.
    /// </summary>
    public interface IRatingsClient : IBaseClient
    {
        /// <summary>
        /// Fetch a user’s rating for an album by using the user's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetAlbumRating(string userToken, string id, IReadOnlyCollection<AlbumRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more albums by using the albums' identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_album_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleAlbumRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<AlbumRelationship> include = null);

        /// <summary>
        /// Add a user’s album rating by using the album's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddAlbumRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s album rating by using the album's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteAlbumRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a music video by using the video's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMusicVideoRating(string userToken, string id, IReadOnlyCollection<MusicVideoRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more music videos by using the music videos' identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_music_video_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleMusicVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<MusicVideoRelationship> include = null);

        /// <summary>
        /// Add a user’s music video rating by using the music video's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddMusicVideoRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s music video rating by using the music video's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteMusicVideoRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a playlist by using the playlist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetPlaylistRating(string userToken, string id, IReadOnlyCollection<PlaylistRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more playlists by using the playlists' identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_playlist_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultiplePlaylistRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<PlaylistRelationship> include = null);

        /// <summary>
        /// Add a user’s playlist rating by using the playlist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddPlaylistRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s playlist rating by using the playlist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeletePlaylistRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a song by using the song's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetSongRating(string userToken, string id, IReadOnlyCollection<SongRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more songs by using the songs' identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_song_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleSongRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<SongRelationship> include = null);

        /// <summary>
        /// Add a user’s song rating by using the song's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddSongRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s song rating by using the song's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteSongRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a station by using the station's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RatingResponse> GetStationRating(string userToken, string id);

        /// <summary>
        /// Fetch the user’s ratings for one or more stations by using the stations' identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_station_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleStationRatings(string userToken, IReadOnlyCollection<string> ids);

        /// <summary>
        /// Add a user’s station rating by using the station's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddStationRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s station rating by using the station's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteStationRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a library music video by using the music video's library identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetLibraryMusicVideoRating(string userToken, string id, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more library music videos by using the library music videos' identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_music_video_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleLibraryMusicVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null);

        /// <summary>
        /// Add a user’s library music video rating by using the library music video's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddLibraryMusicVideoRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s library music video rating by using the library music video's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteLibraryMusicVideoRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a library playlist by using the playlist's library identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetLibraryPlaylistRating(string userToken, string id, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more library playlists by using the library playlists' identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_playlist_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleLibraryPlaylistRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);

        /// <summary>
        /// Add a user’s library playlist rating by using the library playlist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddLibraryPlaylistRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s library playlist rating by using the library playlist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteLibraryPlaylistRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a library song by using the song's library identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetLibrarySongRating(string userToken, string id, IReadOnlyCollection<LibrarySongRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more library songs by using the library songs' identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_songs_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleLibrarySongRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibrarySongRelationship> include = null);

        /// <summary>
        /// Add a user’s library song rating by using the library song's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddLibrarySongRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s library song rating by using the library song's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteLibrarySongRating(string userToken, string id);
    }
}