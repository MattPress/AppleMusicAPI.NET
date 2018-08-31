using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.LibraryResources
{
    /// <summary>
    /// A Resource object that represents a library artist.
    /// https://developer.apple.com/documentation/applemusicapi/libraryartist
    /// </summary>
    /// <inheritdoc />
    public class LibraryArtist : Resource<LibraryArtistAttributes, LibraryArtistRelationships>
    {
        /// <summary>
        /// (Required) This value will always be libraryArtists.
        /// Value: libraryArtists
        /// </summary>
        public override string Type => Constants.Resources.LibraryArtists;
    }
}
