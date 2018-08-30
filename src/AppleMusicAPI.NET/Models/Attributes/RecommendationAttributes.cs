using System;
using AppleMusicAPI.NET.Enums;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a recommendation object.
    /// https://developer.apple.com/documentation/applemusicapi/recommendation/attributes
    /// </summary>
    public class RecommendationAttributes : IAttributes
    {
        /// <summary>
        /// (Required) Whether the recommendation is of group type.
        /// </summary>
        public bool IsGroupRecommendation { get; set; }

        /// <summary>
        /// (Required) The date in UTC format when the recommendation is updated.
        /// </summary>
        public DateTime NextUpdateDate { get; set; }

        /// <summary>
        /// (Required) The localized reason for the recommendation.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// (Required) The resource types supported by the recommendation.
        /// </summary>
        public ResourceType[] ResourceTypes { get; set; }

        /// <summary>
        /// (Required) The localized title for the recommendation.
        /// </summary>
        public string Title { get; set; }
    }
}
