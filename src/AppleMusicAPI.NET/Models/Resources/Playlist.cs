using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a playlist.
    /// https://developer.apple.com/documentation/applemusicapi/playlist
    /// </summary>
    /// <inheritdoc />
    public class Playlist : Resource<PlaylistAttributes, PlaylistRelationships>
    {
        /// <summary>
        /// (Required) This value will always be playlists. Value: playlists
        /// </summary>
        public override string Type => Constants.Resources.Playlists;
    }
}
