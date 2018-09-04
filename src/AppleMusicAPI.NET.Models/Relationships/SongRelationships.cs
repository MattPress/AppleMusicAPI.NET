using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for a song object.
    /// https://developer.apple.com/documentation/applemusicapi/song/relationships
    /// </summary>
    public class SongRelationships : IRelationships
    {
        /// <summary>
        /// The albums associated with the song. By default, albums includes identifiers only.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public AlbumRelationship Albums { get; set; }

        /// <summary>
        /// The artists associated with the song. By default, artists includes identifiers only.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public ArtistRelationship Artists { get; set; }

        /// <summary>
        /// The genres associated with the song. By default, genres is not included.
        /// Fetch limits: None
        /// </summary>
        public GenreRelationship Genres { get; set; }

        /// <summary>
        /// The station associated with the song. By default, station is not included.
        /// Fetch limits: None (one station)
        /// </summary>
        public StationRelationship Stations { get; set; }
    }
}
