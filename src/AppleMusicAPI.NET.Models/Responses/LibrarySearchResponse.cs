using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Results;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a library search request.
    /// https://developer.apple.com/documentation/applemusicapi/librarysearchresponse
    /// </summary>
    /// <inheritdoc />
    public class LibrarySearchResponse : SearchResponseRoot<LibrarySearchResults>
    {
    }
}
