using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for a library album object.
    /// https://developer.apple.com/documentation/applemusicapi/libraryalbum/relationships
    /// </summary>
    public class LibraryAlbumRelationships : IRelationships
    {
        /// <summary>
        /// The library artists associated with the album. By default, artists is not included.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public LibraryArtistRelationship Artists { get; set; }

        /// <summary>
        /// The library songs and library music videos on the album. Only available when fetching single library album resource by ID. By default, tracks includes objects.
        /// Fetch limits: 300 default, 300 maximum
        /// </summary>
        public LibraryTrackRelationship Tracks { get; set; }
    }
}
