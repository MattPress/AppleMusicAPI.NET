using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a library music video.
    /// https://developer.apple.com/documentation/applemusicapi/librarymusicvideo
    /// </summary>
    public class LibraryMusicVideo : Resource<LibraryMusicVideoAttributes, LibraryMusicVideoRelationships>
    {
        /// <summary>
        /// (Required) This value will alway be libraryMusicVideos.
        /// Value: libraryMusicVideos
        /// </summary>
        public override string Type => Constants.Resources.LibraryMusicVideos;
    }
}
