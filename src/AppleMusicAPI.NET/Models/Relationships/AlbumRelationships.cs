using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for an album object.
    /// https://developer.apple.com/documentation/applemusicapi/album/relationships
    /// </summary>
    public class AlbumRelationships : IRelationships
    {
        /// <summary>
        /// The artists associated with the album. By default, artists includes identifiers only.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public ArtistRelationship Artists { get; set; }

        /// <summary>
        /// The genres for the album. By default, genres is not included.
        /// Fetch limits: None
        /// </summary>
        public GenreRelationship Genres { get; set; }

        /// <summary>
        /// The songs and music videos on the album. By default, tracks includes objects.
        /// Fetch limits: 300 default, 300 maximum
        /// </summary>
        public TrackRelationship Tracks { get; set; }
    }
}
