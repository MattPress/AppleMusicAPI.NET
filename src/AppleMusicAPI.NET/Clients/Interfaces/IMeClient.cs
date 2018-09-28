using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    public interface IMeClient : IBaseClient
    {
        /// <summary>
        /// Fetch the resources in heavy rotation for the user.
        /// me/history/heavy-rotation
        /// https://developer.apple.com/documentation/applemusicapi/get_heavy_rotation_content
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<HistoryResponse> GetHeavyRotationContent(string userToken, PageOptions pageOptions = null);

        /// <summary>
        /// Add a catalog resource to a user’s iCloud Music Library.
        /// POST me/library
        /// https://developer.apple.com/documentation/applemusicapi/add_a_resource_to_a_library
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<ResponseRoot> AddResourceToLibrary(string userToken, IReadOnlyDictionary<iCloudMusicLibraryType, List<string>> ids);

        /// <summary>
        /// Fetch a library album by using its identifier.
        /// me/library/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_album
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryAlbumResponse> GetLibraryAlbum(string userToken, string id, IReadOnlyCollection<LibraryAlbumRelationship> include = null);

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
        Task<LibraryAlbumResponse> GetLibraryAlbumRelationship(string userToken, string id, LibraryAlbumRelationship relationship, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch one or more library albums by using their identifiers.
        /// me/library/albums
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_albums
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryAlbumResponse> GetMultipleLibraryAlbums(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryAlbumRelationship> include = null);

        /// <summary>
        /// Fetch all the library albums in alphabetical order.
        /// me/library/albums
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_albums
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<LibraryAlbumResponse> GetAllLibraryAlbums(string userToken, IReadOnlyCollection<LibraryAlbumRelationship> include = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a library artist by using its identifier.
        /// me/library/artists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_artist
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryArtistResponse> GetLibraryArtist(string userToken, string id, IReadOnlyCollection<LibraryArtistRelationship> include = null);

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
        Task<LibraryArtistResponse> GetLibraryArtistRelationship(string userToken, string id, LibraryArtistRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more library artists by using their identifiers.
        /// me/library/artists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_artists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryArtistResponse> GetMultipleLibraryArtists(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryArtistRelationship> include = null);

        /// <summary>
        /// Fetch all the library artists in alphabetical order.
        /// me/library/artists
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_artists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<LibraryArtistResponse> GetAllLibraryArtists(string userToken, IReadOnlyCollection<LibraryArtistRelationship> include = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a library music video by using its identifier.
        /// me/library/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_music_video
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryMusicVideoResponse> GetLibraryMusicVideo(string userToken, string id, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null);

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
        Task<LibraryMusicVideoResponse> GetLibraryMusicVideoRelationship(string userToken, string id, LibraryMusicVideoRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more library music videos by using their identifiers.
        /// me/library/music-videos
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_music_videos
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryMusicVideoResponse> GetMultipleLibraryMusicVideos(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null);

        /// <summary>
        /// Fetch all the library music videos in alphabetical order.
        /// me/library/music-videos
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_music_videos
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<LibraryMusicVideoResponse> GetAllLibraryMusicVideos(string userToken, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a library playlist by using its identifier.
        /// me/library/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_playlist
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryPlaylistResponse> GetLibraryPlaylist(string userToken, string id, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);

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
        Task<LibraryPlaylistResponse> GetLibraryPlaylistRelationship(string userToken, string id, LibraryPlaylistRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more library playlists by using their identifiers.
        /// me/library/playlists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_playlists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryPlaylistResponse> GetMultipleLibraryPlaylists(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);

        /// <summary>
        /// Fetch all the library playlists in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_playlists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<LibraryPlaylistResponse> GetAllLibraryPlaylists(string userToken, IReadOnlyCollection<LibraryPlaylistRelationship> include = null, PageOptions pageOptions = null);

        /// <summary>
        /// Create a new playlist in a user’s library.
        /// POST me/library/playlists
        /// https://developer.apple.com/documentation/applemusicapi/create_a_new_library_playlist
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="request"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryPlaylistResponse> CreateLibraryPlaylist(string userToken, LibraryPlaylistCreationRequest request, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);

        /// <summary>
        /// Fetch the resources recently added to the library.
        /// me/library/recently-added
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_added_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<RecentlyAddedResponse> GetRecentlyAddedResources(string userToken, PageOptions pageOptions = null);

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
        Task<LibrarySearchResponse> LibraryResourcesSearch(string userToken, string term = null, IReadOnlyCollection<LibraryResource> types = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a library song by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_song
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibrarySongResponse> GetLibrarySong(string userToken, string id, IReadOnlyCollection<LibrarySongRelationship> include = null);

        /// <summary>
        /// Fetch a library song's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_song_s_relationship_directly_by_name
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<LibrarySongResponse> GetLibrarySongRelationship(string userToken, string id, LibrarySongRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch a library song by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_song
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibrarySongResponse> GetMultipleLibrarySongs(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibrarySongRelationship> include = null);

        /// <summary>
        /// Fetch all the library songs in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_songs
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<LibrarySongResponse> GetAllLibrarySongs(string userToken, IReadOnlyCollection<LibrarySongRelationship> include = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a user’s rating for an album by using the user's identifier.
        /// me/ratings/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetAlbumRating(string userToken, string id, IReadOnlyCollection<AlbumRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more albums by using the albums' identifiers.
        /// me/ratings/albums
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_album_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleAlbumRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<AlbumRelationship> include = null);

        /// <summary>
        /// Add a user’s album rating by using the album's identifier.
        /// me/ratings/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddAlbumRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s album rating by using the album's identifier.
        /// me/ratings/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_album_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteAlbumRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a music video by using the video's identifier.
        /// me/ratings/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMusicVideoRating(string userToken, string id, IReadOnlyCollection<MusicVideoRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more music videos by using the music videos' identifiers.
        /// me/ratings/music-videos
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_music_video_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleMusicVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<MusicVideoRelationship> include = null);

        /// <summary>
        /// Add a user’s music video rating by using the music video's identifier.
        /// me/ratings/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddMusicVideoRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s music video rating by using the music video's identifier.
        /// me/ratings/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteMusicVideoRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a playlist by using the playlist's identifier.
        /// me/ratings/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetPlaylistRating(string userToken, string id, IReadOnlyCollection<PlaylistRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more playlists by using the playlists' identifiers.
        /// me/ratings/playlists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_playlist_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultiplePlaylistRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<PlaylistRelationship> include = null);

        /// <summary>
        /// Add a user’s playlist rating by using the playlist's identifier.
        /// me/ratings/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddPlaylistRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s playlist rating by using the playlist's identifier.
        /// me/ratings/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeletePlaylistRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a song by using the song's identifier.
        /// me/ratings/songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetSongRating(string userToken, string id, IReadOnlyCollection<SongRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more songs by using the songs' identifiers.
        /// me/ratings/songs
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_song_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleSongRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<SongRelationship> include = null);

        /// <summary>
        /// Add a user’s song rating by using the song's identifier.
        /// me/ratings/songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddSongRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s song rating by using the song's identifier.
        /// me/ratings/songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteSongRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a station by using the station's identifier.
        /// me/ratings/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RatingResponse> GetStationRating(string userToken, string id);

        /// <summary>
        /// Fetch the user’s ratings for one or more stations by using the stations' identifiers.
        /// me/ratings/stations
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_station_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleStationRatings(string userToken, IReadOnlyCollection<string> ids);

        /// <summary>
        /// Add a user’s station rating by using the station's identifier.
        /// me/ratings/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddStationRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s station rating by using the station's identifier.
        /// me/ratings/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_station_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteStationRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a library music video by using the music video's library identifier.
        /// me/ratings/library-music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetLibraryMusicVideoRating(string userToken, string id, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more library music videos by using the library music videos' identifiers.
        /// me/ratings/library-music-videos
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_music_video_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleLibraryMusicVideoRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null);

        /// <summary>
        /// Add a user’s library music video rating by using the library music video's identifier.
        /// me/ratings/library-music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddLibraryMusicVideoRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s library music video rating by using the library music video's identifier.
        /// me/ratings/library-music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_music_video_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteLibraryMusicVideoRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a library playlist by using the playlist's library identifier.
        /// me/ratings/library-playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetLibraryPlaylistRating(string userToken, string id, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more library playlists by using the library playlists' identifiers.
        /// me/ratings/library-playlists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_playlist_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleLibraryPlaylistRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);

        /// <summary>
        /// Add a user’s library playlist rating by using the library playlist's identifier.
        /// me/ratings/library-playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddLibraryPlaylistRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s library playlist rating by using the library playlist's identifier.
        /// me/ratings/library-playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_playlist_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteLibraryPlaylistRating(string userToken, string id);

        /// <summary>
        /// Fetch a user’s rating for a library song by using the song's library identifier.
        /// me/ratings/library-songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetLibrarySongRating(string userToken, string id, IReadOnlyCollection<LibrarySongRelationship> include = null);

        /// <summary>
        /// Fetch the user’s ratings for one or more library songs by using the library songs' identifiers.
        /// me/ratings/library-songs
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_personal_library_songs_ratings
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<RatingResponse> GetMultipleLibrarySongRatings(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibrarySongRelationship> include = null);

        /// <summary>
        /// Add a user’s library song rating by using the library song's identifier.
        /// me/ratings/library-songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/add_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RatingResponse> AddLibrarySongRating(string userToken, string id, RatingRequest request);

        /// <summary>
        /// Remove a user’s library song rating by using the library song's identifier.
        /// me/ratings/library-songs/{id}
        /// https://developer.apple.com/documentation/applemusicapi/delete_a_personal_library_song_rating
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseRoot> DeleteLibrarySongRating(string userToken, string id);

        /// <summary>
        /// Fetch the recently played resources for the user.
        /// me/recent/played
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_played_resources
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<HistoryResponse> GetRecentlyPlayedResources(string userToken, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch recently played radio stations for the user.
        /// me/recent/radio-stations
        /// https://developer.apple.com/documentation/applemusicapi/get_recently_played_stations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<HistoryResponse> GetRecentlyPlayedStations(string userToken, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a recommendation by using its identifier.
        /// me/recommendations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_recommendation
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<RecommendationResponse> GetRecommendation(string userToken, string id, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch one or more recommendations by using their identifiers.
        /// me/recommendations
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_recommendations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<RecommendationResponse> GetMultipleRecommendations(string userToken, IReadOnlyCollection<string> ids, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch default recommendations.
        /// me/recommendations
        /// https://developer.apple.com/documentation/applemusicapi/get_default_recommendations
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="recommendationType"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<RecommendationResponse> GetDefaultRecommendations(string userToken, RecommendationType? recommendationType = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a user’s storefront.
        /// me/storefront
        /// https://developer.apple.com/documentation/applemusicapi/get_a_user_s_storefront
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        Task<StorefrontResponse> GetUsersStorefront(string userToken);
    }
}