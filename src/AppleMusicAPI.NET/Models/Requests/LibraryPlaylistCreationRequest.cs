using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Requests
{
    /// <summary>
    /// A request to create a new playlist in a user's library.
    /// https://developer.apple.com/documentation/applemusicapi/libraryplaylistcreationrequest
    /// </summary>
    public class LibraryPlaylistCreationRequest
    {
        /// <summary>
        /// (Required) A dictionary that includes strings for the name and description of the new playlist.
        /// </summary>
        public LibraryPlaylistCreationRequestAttributes Attributes { get; set; }

        /// <summary>
        /// An optional key including tracks for the new playlist.
        /// </summary>
        public LibraryPlaylistCreationRequestRelationships Relationships { get; set; }
    }
}
