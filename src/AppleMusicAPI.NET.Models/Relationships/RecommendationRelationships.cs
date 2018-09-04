using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for a recommendation object.
    /// https://developer.apple.com/documentation/applemusicapi/recommendation/relationships
    /// </summary>
    public class RecommendationRelationships : IRelationships
    {
        /// <summary>
        /// The contents associated with the content recommendation type. By default, contents includes objects.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public Relationship Contents { get; set; }

        /// <summary>
        /// The recommendations associated with the group recommendation type. By default, recommendations includes objects.
        /// Fetch limits: None
        /// </summary>
        public Relationship Recommendations { get; set; }
    }
}
