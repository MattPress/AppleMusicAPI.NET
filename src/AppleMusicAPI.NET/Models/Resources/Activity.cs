using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents an activity.
    /// https://developer.apple.com/documentation/applemusicapi/activity
    /// </summary>
    /// <inheritdoc />
    public class Activity : Resource<ActivityAttributes, ActivityRelationships>
    {
        /// <summary>
        /// (Required) Always activities.
        /// Value: activities
        /// </summary>
        public override string Type => Constants.Resources.Activities;
    }
}
