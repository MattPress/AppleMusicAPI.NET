using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.LibraryResources;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a library playlist request.
    /// https://developer.apple.com/documentation/applemusicapi/libraryplaylistresponse
    /// </summary>
    /// <inheritdoc />
    public class LibraryPlaylistResponse : DataResponseRoot<LibraryPlaylist>
    {
    }
}
