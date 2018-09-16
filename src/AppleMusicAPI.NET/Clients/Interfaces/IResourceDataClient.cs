using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    public interface IResourceDataClient
    {
        /// <summary>
        /// Fetch an album by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_album
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<AlbumResponse> GetCatalogAlbum(string id, string storefront, IReadOnlyCollection<AlbumRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch an album's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_album_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<AlbumResponse> GetCatalogAlbumRelationship(string id, string storefront, AlbumRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more albums by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_albums
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<AlbumResponse> GetMultipleCatalogAlbums(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AlbumRelationship> include = null);

        /// <summary>
        /// Fetch a music video by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_music_video
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<MusicVideoResponse> GetCatalogMusicVideo(string id, string storefront, IReadOnlyCollection<MusicVideoRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch a music video's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_music_video_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<MusicVideoResponse> GetCatalogMusicVideoRelationship(string id, string storefront, MusicVideoRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more music videos by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_music_videos_by_id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="isrc"></param>
        /// <returns></returns>
        Task<MusicVideoResponse> GetMultipleCatalogMusicVideos(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<MusicVideoRelationship> include = null, string isrc = null);

        /// <summary>
        /// Fetch one or more music videos by using their ISRC values.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_music_videos_by_isrc
        /// </summary>
        /// <param name="isrc"></param>
        /// <param name="storefront"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<MusicVideoResponse> GetMultipleCatalogMusicVideosByIsrc(string isrc, string storefront, IReadOnlyCollection<string> ids = null, IReadOnlyCollection<MusicVideoRelationship> include = null);

        /// <summary>
        /// Fetch a playlist by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_playlist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<PlaylistResponse> GetCatalogPlaylist(string id, string storefront, IReadOnlyCollection<PlaylistRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch a playlist's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_playlist_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<PlaylistResponse> GetCatalogPlaylistRelationship(string id, string storefront, PlaylistRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more playlists by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_playlists
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<PlaylistResponse> GetMultipleCatalogPlaylists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<PlaylistRelationship> include = null);

        /// <summary>
        /// Fetch a song by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_song
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<SongResponse> GetCatalogSong(string id, string storefront, IReadOnlyCollection<SongRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch a song's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_song_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<SongResponse> GetCatalogSongRelationship(string id, string storefront, SongRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more songs by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_songs_by_id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <param name="isrc"></param>
        /// <returns></returns>
        Task<SongResponse> GetMultipleCatalogSongs(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<SongRelationship> include = null, string isrc = null);

        /// <summary>
        /// Fetch one or more songs by using their ISRC values.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_songs_by_isrc
        /// </summary>
        /// <param name="isrc"></param>
        /// <param name="storefront"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<SongResponse> GetMultipleCatalogSongsByIsrc(string isrc, string storefront, IReadOnlyCollection<string> ids = null, IReadOnlyCollection<SongRelationship> include = null);

        /// <summary>
        /// Fetch a station by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_station
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<StationResponse> GetCatalogStation(string id, string storefront);

        /// <summary>
        /// Fetch one or more stations by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_stations
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        Task<StationResponse> GetMultipleCatalogStations(IReadOnlyCollection<string> ids, string storefront);

        /// <summary>
        /// Fetch an artist by using the artist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_artist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<ArtistResponse> GetCatalogArtist(string id, string storefront, IReadOnlyCollection<ArtistRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch an artist's relationship by using the artist's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_artist_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ArtistResponse> GetCatalogArtistRelationship(string id, string storefront, ArtistRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more artists by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_artists
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<ArtistResponse> GetMultipleCatalogArtists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ArtistRelationship> include = null);

        /// <summary>
        /// Fetch a curator by using the curator's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_curator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<CuratorResponse> GetCatalogCurator(string id, string storefront, IReadOnlyCollection<CuratorRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch a curator's relationship by using the curator's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_curator_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<CuratorResponse> GetCatalogCuratorRelationship(string id, string storefront, CuratorRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more curators by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_curators
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<CuratorResponse> GetMultipleCatalogCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<CuratorRelationship> include = null);

        /// <summary>
        /// Fetch an activity by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_activity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<ActivityResponse> GetCatalogActivity(string id, string storefront, IReadOnlyCollection<ActivityRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch an activity's relationship by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_activity_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ActivityResponse> GetCatalogActivityRelationship(string id, string storefront, ActivityRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more activities by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_activities
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<ActivityResponse> GetMultipleCatalogActivities(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ActivityRelationship> include = null);

        /// <summary>
        /// Fetch an Apple curator by using the curator's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_apple_curator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<AppleCuratorResponse> GetCatalogAppleCurator(string id, string storefront, IReadOnlyCollection<AppleCuratorRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch an Apple curator's relationship by using the curator's identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_apple_curator_s_relationship_directly_by_name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationship"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<AppleCuratorResponse> GetCatalogAppleCuratorRelationship(string id, string storefront, AppleCuratorRelationship relationship, int? limit = null);

        /// <summary>
        /// Fetch one or more Apple curators by using their identifiers.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_apple_curators
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<AppleCuratorResponse> GetMultipleCatalogAppleCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AppleCuratorRelationship> include = null);

        /// <summary>
        /// Fetch a genre by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_genre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        Task<GenreResponse> GetCatalogGenre(string id, string storefront);

        /// <summary>
        /// Fetch one or more genres.
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_genres
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        Task<GenreResponse> GetMultipleCatalogGenres(IReadOnlyCollection<string> ids, string storefront);

        /// <summary>
        /// Fetch all genres for the current top charts.
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_top_charts_genres
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<GenreResponse> GetCatalogTopChartsGenres(string storefront, PageOptions pageOptions);

        /// <summary>
        /// Fetch a library album by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_album
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryAlbumResponse> GetLibraryAlbum(string userToken, string id, IReadOnlyCollection<LibraryAlbumRelationship> include = null);

        /// <summary>
        /// Fetch a library album's relationship by using its identifier.
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
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_albums
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryAlbumResponse> GetMultipleLibraryAlbums(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryAlbumRelationship> include = null);

        /// <summary>
        /// Fetch all the library albums in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_albums
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<LibraryAlbumResponse> GetAllLibraryAlbums(string userToken, IReadOnlyCollection<LibraryAlbumRelationship> include = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a library artist by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_artist
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryArtistResponse> GetLibraryArtist(string userToken, string id, IReadOnlyCollection<LibraryArtistRelationship> include = null);

        /// <summary>
        /// Fetch a library artist's relationship by using its identifier.
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
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_artists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryArtistResponse> GetMultipleLibraryArtists(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryArtistRelationship> include = null);

        /// <summary>
        /// Fetch all the library artists in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_artists
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<LibraryArtistResponse> GetAllLibraryArtists(string userToken, IReadOnlyCollection<LibraryArtistRelationship> include = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a library music video by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_music_video
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryMusicVideoResponse> GetLibraryMusicVideo(string userToken, string id, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null);

        /// <summary>
        /// Fetch a library music video's relationship by using its identifier.
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
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_library_music_videos
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryMusicVideoResponse> GetMultipleLibraryMusicVideos(string userToken, IReadOnlyCollection<string> ids, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null);

        /// <summary>
        /// Fetch all the library music videos in alphabetical order.
        /// https://developer.apple.com/documentation/applemusicapi/get_all_library_music_videos
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="include"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<LibraryMusicVideoResponse> GetAllLibraryMusicVideos(string userToken, IReadOnlyCollection<LibraryMusicVideoRelationship> include = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a library playlist by using its identifier.
        /// https://developer.apple.com/documentation/applemusicapi/get_a_library_playlist
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryPlaylistResponse> GetLibraryPlaylist(string userToken, string id, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);

        /// <summary>
        /// Fetch a library playlist's relationship by using its identifier.
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
    }
}