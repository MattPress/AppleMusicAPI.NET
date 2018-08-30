using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for a library playlist object.
    /// https://developer.apple.com/documentation/applemusicapi/libraryplaylist/relationships
    /// </summary>
    public class LibraryPlaylistRelationships : IRelationships
    {
        /// <summary>
        /// The library songs and library music videos included in the playlist. By default, tracks is not included. Only available when fetching a single library playlist resource by ID.
        /// Fetch limits: 100 default, 100 maximum
        /// </summary>
        public LibraryTrackRelationship Tracks { get; set; }
    }
}
