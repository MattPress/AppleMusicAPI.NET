using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a music video.
    /// https://developer.apple.com/documentation/applemusicapi/musicvideo
    /// </summary>
    /// <inheritdoc />
    public class MusicVideo : Resource<MusicVideoAttributes, MusicVideoRelationships>
    {
        /// <summary>
        /// The attributes for the music video.
        /// </summary>
        public override string Type => Constants.Resources.MusicVideos;
    }
}
