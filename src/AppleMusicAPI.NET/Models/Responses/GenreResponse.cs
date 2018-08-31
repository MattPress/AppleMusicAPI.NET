using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Resources;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a genre request.
    /// https://developer.apple.com/documentation/applemusicapi/genreresponse
    /// </summary>
    /// <inheritdoc />
    public class GenreResponse : DataResponseRoot<Genre>
    {
    }
}
