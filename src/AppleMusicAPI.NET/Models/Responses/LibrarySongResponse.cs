using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.LibraryResources;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a library song request.
    /// https://developer.apple.com/documentation/applemusicapi/librarysongresponse
    /// </summary>
    /// <inheritdoc />
    public class LibrarySongResponse : DataResponseRoot<LibrarySong>
    {
    }
}
