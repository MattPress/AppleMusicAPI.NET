using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for a music video object.
    /// https://developer.apple.com/documentation/applemusicapi/musicvideo/relationships
    /// </summary>
    public class MusicVideoRelationships : IRelationships
    {
        /// <summary>
        /// The albums associated with the music video. By default, albums includes identifiers only.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public AlbumRelationship Albums { get; set; }

        /// <summary>
        /// The artists associated with the music video. By default, artists includes identifiers only.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public ArtistRelationship Artists { get; set; }

        /// <summary>
        /// The genres associated with the music video. By default, genres is not included.
        /// Fetch limits: None
        /// </summary>
        public GenreRelationship Genres { get; set; }
    }
}
