using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a library playlist creation request object.
    /// https://developer.apple.com/documentation/applemusicapi/libraryplaylistcreationrequest/attributes
    /// </summary>
    public class LibraryPlaylistCreationRequestAttributes : IAttributes
    {
        /// <summary>
        /// The description of the playlist.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// (Required) The name of the playlist.
        /// </summary>
        public string Name { get; set; }
    }
}
