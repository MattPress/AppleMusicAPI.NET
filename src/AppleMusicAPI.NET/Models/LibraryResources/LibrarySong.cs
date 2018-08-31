using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.LibraryResources
{
    /// <summary>
    /// A Resource object that represents a library song.
    /// https://developer.apple.com/documentation/applemusicapi/librarysong
    /// </summary>
    public class LibrarySong : Resource<LibrarySongAttributes, LibrarySongRelationships>
    {
        /// <summary>
        /// (Required) This value will alway be librarySongs.
        /// Value: librarySongs
        /// </summary>
        public override string Type => Constants.Resources.LibrarySongs;
    }
}
