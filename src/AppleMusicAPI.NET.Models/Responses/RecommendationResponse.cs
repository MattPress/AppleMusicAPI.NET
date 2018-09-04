using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Resources;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a recommendation request.
    /// https://developer.apple.com/documentation/applemusicapi/recommendationresponse
    /// </summary>
    /// <inheritdoc />
    public class RecommendationResponse : DataResponseRoot<Recommendation>
    {
    }
}
