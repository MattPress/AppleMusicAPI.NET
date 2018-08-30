using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a library album.
    /// https://developer.apple.com/documentation/applemusicapi/libraryalbum
    /// </summary>
    public class LibraryAlbum : Resource<LibraryAlbumAttributes, LibraryAlbumRelationships>
    {
        /// <summary>
        /// (Required) This value will always be libraryAlbums.
        /// Value: libraryAlbums
        /// </summary>
        public override string Type => Constants.Resources.LibraryAlbums;
    }
}
