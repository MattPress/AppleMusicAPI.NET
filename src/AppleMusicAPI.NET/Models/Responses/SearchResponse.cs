using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Results;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a search request.
    /// https://developer.apple.com/documentation/applemusicapi/searchresponse
    /// </summary>
    /// <inheritdoc />
    public class SearchSearchResponse : SearchResponseRoot<SearchResults>
    {
    }
}
