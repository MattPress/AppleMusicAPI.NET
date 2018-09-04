using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Resources;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to an artist request.
    /// https://developer.apple.com/documentation/applemusicapi/artistresponse
    /// </summary>
    /// <inheritdoc />
    public class ArtistResponse : DataResponseRoot<Artist>
    {
    }
}
