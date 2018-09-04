using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents an album.
    /// https://developer.apple.com/documentation/applemusicapi/album
    /// </summary>
    /// <inheritdoc />
    public class Album : Resource<AlbumAttributes, AlbumRelationships>
    {
        /// <summary>
        /// (Required) This value will always be albums.
        /// Value: albums
        /// </summary>
        public override string Type => Constants.Resources.Albums;
    }
}
