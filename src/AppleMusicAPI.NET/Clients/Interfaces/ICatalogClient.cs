using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    public interface ICatalogClient
    {
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
        Task<ActivityResponse> GetCatalogActivity(string id, string storefront, IReadOnlyCollection<ActivityRelationship> relationshipsToInclude = null, string locale = null);

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
        Task<ActivityResponse> GetCatalogActivityRelationship(string id, string storefront, ActivityRelationship relationship, int? limit = null);

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
        Task<ActivityResponse> GetMultipleCatalogActivities(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ActivityRelationship> include = null, string locale = null);

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
        Task<AlbumResponse> GetCatalogAlbum(string id, string storefront, IReadOnlyCollection<AlbumRelationship> relationshipsToInclude = null, string locale = null);

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
        Task<AlbumResponse> GetCatalogAlbumRelationship(string id, string storefront, AlbumRelationship relationship, int? limit = null, string locale = null);

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
        Task<AlbumResponse> GetMultipleCatalogAlbums(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AlbumRelationship> include = null, string locale = null);

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
        Task<AppleCuratorResponse> GetCatalogAppleCurator(string id, string storefront, IReadOnlyCollection<AppleCuratorRelationship> relationshipsToInclude = null, string locale = null);

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
        Task<AppleCuratorResponse> GetCatalogAppleCuratorRelationship(string id, string storefront, AppleCuratorRelationship relationship, int? limit = null, string locale = null);

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
        Task<AppleCuratorResponse> GetMultipleCatalogAppleCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<AppleCuratorRelationship> include = null, string locale = null);

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
        Task<ArtistResponse> GetCatalogArtist(string id, string storefront, IReadOnlyCollection<ArtistRelationship> relationshipsToInclude = null, string locale = null);

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
        Task<ArtistResponse> GetCatalogArtistRelationship(string id, string storefront, ArtistRelationship relationship, int? limit = null, string locale = null);

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
        Task<ArtistResponse> GetMultipleCatalogArtists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<ArtistRelationship> include = null, string locale = null);

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
        Task<ChartResponse> GetCatalogCharts(string storefront, IReadOnlyCollection<CatalogChartType> types = null, string chart = null, string genre = null, PageOptions pageOptions = null, string locale = null);

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
        Task<CuratorResponse> GetCatalogCurator(string id, string storefront, IReadOnlyCollection<CuratorRelationship> relationshipsToInclude = null, string locale = null);

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
        Task<CuratorResponse> GetCatalogCuratorRelationship(string id, string storefront, CuratorRelationship relationship, int? limit = null, string locale = null);

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
        Task<CuratorResponse> GetMultipleCatalogCurators(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<CuratorRelationship> include = null, string locale = null);

        /// <summary>
        /// Fetch a genre by using its identifier.
        /// Route: catalog/{storefront}/genres/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_genre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<GenreResponse> GetCatalogGenre(string id, string storefront, string locale = null);

        /// <summary>
        /// Fetch one or more genres.
        /// Route: catalog/{storefront}/genres
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_genres
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<GenreResponse> GetMultipleCatalogGenres(IReadOnlyCollection<string> ids, string storefront, string locale = null);

        /// <summary>
        /// Fetch all genres for the current top charts.
        /// Route: catalog/{storefront}/genres
        /// https://developer.apple.com/documentation/applemusicapi/get_catalog_top_charts_genres
        /// </summary>
        /// <param name="storefront"></param>
        /// <param name="pageOptions"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<GenreResponse> GetCatalogTopChartsGenres(string storefront, PageOptions pageOptions = null, string locale = null);

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
        Task<MusicVideoResponse> GetCatalogMusicVideo(string id, string storefront, IReadOnlyCollection<MusicVideoRelationship> relationshipsToInclude = null, string locale = null);

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
        Task<MusicVideoResponse> GetCatalogMusicVideoRelationship(string id, string storefront, MusicVideoRelationship relationship, int? limit = null, string locale = null);

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
        Task<MusicVideoResponse> GetMultipleCatalogMusicVideos(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<MusicVideoRelationship> include = null, string isrc = null, string locale = null);

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
        Task<MusicVideoResponse> GetMultipleCatalogMusicVideosByIsrc(string isrc, string storefront, IReadOnlyCollection<string> ids = null, IReadOnlyCollection<MusicVideoRelationship> include = null, string locale = null);

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
        Task<PlaylistResponse> GetCatalogPlaylist(string id, string storefront, IReadOnlyCollection<PlaylistRelationship> relationshipsToInclude = null, string locale = null);

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
        Task<PlaylistResponse> GetCatalogPlaylistRelationship(string id, string storefront, PlaylistRelationship relationship, int? limit = null, string locale = null);

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
        Task<PlaylistResponse> GetMultipleCatalogPlaylists(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<PlaylistRelationship> include = null, string locale = null);

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
        Task<SearchResponse> CatalogResourcesSearch(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null, string locale = null);

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
        Task<SearchHintsResponse> GetCatalogSearchHints(string storefront, string term = null, IReadOnlyCollection<ResourceType> types = null, PageOptions pageOptions = null, string locale = null);

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
        Task<SongResponse> GetCatalogSong(string id, string storefront, IReadOnlyCollection<SongRelationship> relationshipsToInclude = null, string locale = null);

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
        Task<SongResponse> GetCatalogSongRelationship(string id, string storefront, SongRelationship relationship, int? limit = null, string locale = null);

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
        Task<SongResponse> GetMultipleCatalogSongs(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<SongRelationship> include = null, string isrc = null, string locale = null);

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
        Task<SongResponse> GetMultipleCatalogSongsByIsrc(string isrc, string storefront, IReadOnlyCollection<string> ids = null, IReadOnlyCollection<SongRelationship> include = null, string locale = null);

        /// <summary>
        /// Fetch a station by using its identifier.
        /// Route: catalog/{storefront}/stations/{id}
        /// https://developer.apple.com/documentation/applemusicapi/get_a_catalog_station
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storefront"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<StationResponse> GetCatalogStation(string id, string storefront, string locale = null);

        /// <summary>
        /// Fetch one or more stations by using their identifiers.
        /// Route: catalog/{storefront}/stations
        /// https://developer.apple.com/documentation/applemusicapi/get_multiple_catalog_stations
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="storefront"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<StationResponse> GetMultipleCatalogStations(IReadOnlyCollection<string> ids, string storefront, string locale = null);
    }
}