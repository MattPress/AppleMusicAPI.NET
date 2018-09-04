using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Resources;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a song request.
    /// https://developer.apple.com/documentation/applemusicapi/songresponse
    /// </summary>
    /// <inheritdoc />
    public class SongResponse : DataResponseRoot<Song>
    {
    }
}
