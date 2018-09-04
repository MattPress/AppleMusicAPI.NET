using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a song.
    /// https://developer.apple.com/documentation/applemusicapi/song
    /// </summary>
    /// <inheritdoc />
    public class Song : Resource<SongAttributes, SongRelationships>
    {
        /// <summary>
        /// (Required) This value will always be songs.
        /// Value: songs
        /// </summary>
        public override string Type => Constants.Resources.Songs;
    }
}
