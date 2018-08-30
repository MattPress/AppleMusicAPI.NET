namespace AppleMusicAPI.NET.Models.Requests
{
    /// <summary>
    /// An object that represents a single track when added to a library playlist in a request.
    /// https://developer.apple.com/documentation/applemusicapi/libraryplaylistrequesttrack
    /// </summary>
    public class LibraryPlaylistRequestTrack
    {
        /// <summary>
        /// (Required) The unique identifier for the track. This ID can be a catalog identifier or a library identifier, depending on the track type.
        /// </summary>
        public string Id { get; set; }

        // TODO - MJP - Create enum
        /// <summary>
        /// (Required) The type of the track to be added. The possible values are songs, music-videos, library-songs, or library-music-videos.
        /// </summary>
        public string Type { get; set; }
    }
}