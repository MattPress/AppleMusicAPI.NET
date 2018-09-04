using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for a library music video object.
    /// https://developer.apple.com/documentation/applemusicapi/librarymusicvideo/relationships
    /// </summary>
    public class LibraryMusicVideoRelationships : IRelationships
    {
        /// <summary>
        /// The library albums associated with the music video. By default, albums is not included.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public LibraryAlbumRelationship Albums { get; set; }

        /// <summary>
        /// The library artists associated with the music video. By default, artists is not included.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public LibraryArtistRelationship Artists { get; set; }
    }
}
