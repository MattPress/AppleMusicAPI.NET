using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents recommended resources for a user calculated using their selected preferences.
    /// https://developer.apple.com/documentation/applemusicapi/recommendation
    /// </summary>
    /// <inheritdoc />
    public class Recommendation : Resource<RecommendationAttributes, RecommendationRelationships>
    {
        /// <summary>
        /// (Required) This value will always be personal-recommendation.
        /// Value: personal-recommendation
        /// </summary>
        public override string Type => Constants.Resources.Recommendation;
    }
}
