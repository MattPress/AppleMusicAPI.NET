using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Results;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a search hints request.
    /// https://developer.apple.com/documentation/applemusicapi/searchhintsresponse
    /// </summary>
    /// <inheritdoc />
    public class SearchHintsResponse : ResponseRoot<Resource, SearchHints>
    {
    }
}
