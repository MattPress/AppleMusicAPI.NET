
namespace AppleMusicAPI.NET.Models.Requests
{
    /// <summary>
    /// A request to add tracks to a library playlist.
    /// https://developer.apple.com/documentation/applemusicapi/libraryplaylisttracksrequest
    /// </summary>
    public class LibraryPlaylistTracksRequest
    {
        /// <summary>
        /// (Required) A list of dictionaries with information about the tracks to add.
        /// </summary>
        public LibraryPlaylistRequestTrack[] Data { get; set; }
    }
}
