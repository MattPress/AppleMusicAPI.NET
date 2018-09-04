using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for an artist object.
    /// https://developer.apple.com/documentation/applemusicapi/artist/relationships
    /// </summary>
    public class ArtistRelationships : IRelationships
    {
        /// <summary>
        /// The albums associated with the artist. By default, albums includes identifiers only.
        /// Fetch limits: 25 default, 100 maximum
        /// </summary>
        public AlbumRelationship Albums { get; set; }

        /// <summary>
        /// The genres associated with the artist. By default, genres is not included.
        /// Fetch limits: None
        /// </summary>
        public GenreRelationship Genres { get; set; }

        /// <summary>
        /// The music videos associated with the artist. By default, musicVideos is not included.
        /// Fetch limits: 25 default, 100 maximum
        /// </summary>
        public MusicVideoRelationship MusicVideos { get; set; }

        /// <summary>
        /// The playlists associated with the artist. By default, playlists is not included.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public PlaylistRelationship Playlists { get; set; }

        /// <summary>
        /// The station associated with the artist. By default, station is not included.
        /// Fetch limits: None (one station)
        /// </summary>
        public StationRelationship Stations { get; set; }
    }
}
