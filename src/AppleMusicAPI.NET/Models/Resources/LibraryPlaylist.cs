using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a library playlist.
    /// https://developer.apple.com/documentation/applemusicapi/libraryplaylist
    /// </summary>
    public class LibraryPlaylist : Resource<LibraryPlaylistAttributes, LibraryPlaylistRelationships>
    {
        /// <summary>
        /// (Required) This value will alway be libraryPlaylists.
        /// Value: libraryPlaylists
        /// </summary>
        public override string Type => Constants.Resources.LibraryPlaylists;
    }
}
