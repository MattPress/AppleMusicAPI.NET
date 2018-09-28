using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    public interface ICatalogClient : IBaseClient
    {
        /// <summary>
        /// Fetch an activity by using its identifier.
        /// catalog/{storefront}/activities/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_activity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<ActivityResponse> GetCatalogActivity(string id, string storefront, IReadOnlyCollection<ActivityRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch an activity's relationship by using its identifier.
        /// catalog/{storefront}/activities/{id}/{relationship}
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
        /// catalog/{storefront}/activities
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_activities
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<ActivityResponse> GetMultipleCatalogActivities(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ActivityRelationship> include = null);

        /// <summary>
        /// Fetch an album by using its identifier.
        /// catalog/{storefront}/albums/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_album
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<AlbumResponse> GetCatalogAlbum(string id, string storefront, IReadOnlyCollection<AlbumRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch an album's relationship by using its identifier.
        /// catalog/{storefront}/albums/{id}/{relationship}
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
        /// catalog/{storefront}/albums
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_albums
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<AlbumResponse> GetMultipleCatalogAlbums(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AlbumRelationship> include = null);

        /// <summary>
        /// Fetch an Apple curator by using the curator's identifier.
        /// catalog/{storefront}/apple-curators/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_apple_curator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<AppleCuratorResponse> GetCatalogAppleCurator(string id, string storefront, IReadOnlyCollection<AppleCuratorRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch an Apple curator's relationship by using the curator's identifier.
        /// catalog/{storefront}/apple-curators/{id}/{relationship}
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
        /// catalog/{storefront}/apple-curators
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_apple_curators
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<AppleCuratorResponse> GetMultipleCatalogAppleCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AppleCuratorRelationship> include = null);

        /// <summary>
        /// Fetch an artist by using the artist's identifier.
        /// catalog/{storefront}/artists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_artist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<ArtistResponse> GetCatalogArtist(string id, string storefront, IReadOnlyCollection<ArtistRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch an artist's relationship by using the artist's identifier.
        /// catalog/{storefront}/artists/{id}/{relationship}
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
        /// catalog/{storefront}/artists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_artists
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<ArtistResponse> GetMultipleCatalogArtists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ArtistRelationship> include = null);

        /// <summary>
        /// Fetch one or more charts from the Apple Music Catalog.
        /// catalog/{storefront}/charts
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_charts
        /// </summary>
        /// <returns></returns>
        Task<ChartResponse> GetCatalogCharts(string storefront, IReadOnlyCollection<CatalogChartType> types = null, string chart = null, string genre = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a curator by using the curator's identifier.
        /// catalog/{storefront}/curators/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_curator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<CuratorResponse> GetCatalogCurator(string id, string storefront, IReadOnlyCollection<CuratorRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch a curator's relationship by using the curator's identifier.
        /// catalog/{storefront}/curators/{id}/{relationship}
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
        /// catalog/{storefront}/curators
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_curators
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<CuratorResponse> GetMultipleCatalogCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<CuratorRelationship> include = null);

        /// <summary>
        /// Fetch a genre by using its identifier.
        /// catalog/{storefront}/genres/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_genre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        Task<GenreResponse> GetCatalogGenre(string id, string storefront);

        /// <summary>
        /// Fetch one or more genres.
        /// catalog/{storefront}/genres
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_genres
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        Task<GenreResponse> GetMultipleCatalogGenres(IReadOnlyCollection<string> ids, string storefront);

        /// <summary>
        /// Fetch all genres for the current top charts.
        /// catalog/{storefront}/genres
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_top_charts_genres
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<GenreResponse> GetCatalogTopChartsGenres(string storefront, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a music video by using its identifier.
        /// catalog/{storefront}/music-videos/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_music_video
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<MusicVideoResponse> GetCatalogMusicVideo(string id, string storefront, IReadOnlyCollection<MusicVideoRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch a music video's relationship by using its identifier.
        /// catalog/{storefront}/music-videos/{id}/{relationship}
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
        /// catalog/{storefront}/music-videos
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
        /// catalog/{storefront}/music-videos
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
        /// catalog/{storefront}/playlists/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_playlist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<PlaylistResponse> GetCatalogPlaylist(string id, string storefront, IReadOnlyCollection<PlaylistRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch a playlist's relationship by using its identifier.
        /// catalog/{storefront}/playlists/{id}/{relationship}
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
        /// catalog/{storefront}/playlists
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_playlists
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<PlaylistResponse> GetMultipleCatalogPlaylists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<PlaylistRelationship> include = null);

        /// <summary>
        /// Search the catalog by using a query.
        /// catalog/{storefront}/search
        /// https://developer.apple.com/documentation/applemusicapi/search_for_catalog_resources
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<SearchResponse> CatalogResourcesSearch(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch the search term results for a hint.
        /// catalog/{storefront}/search/hints
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_search_hints
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="term"></param>
        /// <param name="types"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        Task<SearchHintsResponse> GetCatalogSearchHints(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null);

        /// <summary>
        /// Fetch a song by using its identifier.
        /// catalog/{storefront}/songs
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_song
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<SongResponse> GetCatalogSong(string id, string storefront, IReadOnlyCollection<SongRelationship> relationshipsToInclude = null);

        /// <summary>
        /// Fetch a song's relationship by using its identifier.
        /// catalog/{storefront}/songs/{id}/{relationship}
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
        /// catalog/{storefront}/songs
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
        /// catalog/{storefront}/songs
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
        /// catalog/{storefront}/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_station
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="relationshipsToInclude"></param>
        /// <returns></returns>
        Task<StationResponse> GetCatalogStation(string id, string storefront);

        /// <summary>
        /// Fetch one or more stations by using their identifiers.
        /// catalog/{storefront}/stations
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_stations
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <returns></returns>
        Task<StationResponse> GetMultipleCatalogStations(IReadOnlyCollection<string> ids, string storefront);
    }
}