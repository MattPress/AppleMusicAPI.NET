using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for a library artist object.
    /// https://developer.apple.com/documentation/applemusicapi/libraryartist/relationships
    /// </summary>
    public class LibraryArtistRelationships : IRelationships
    {
        /// <summary>
        /// The library albums associated with the artist. By default, albums is not included. It is available only when fetching a single library artist resource by ID.
        /// Fetch limits: 25 default, 100 maximum
        /// </summary>
        public LibraryAlbumRelationship Albums { get; set; }
    }
}
