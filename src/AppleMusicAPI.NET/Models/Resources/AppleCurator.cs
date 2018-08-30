using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents an Apple curator.
    /// https://developer.apple.com/documentation/applemusicapi/applecurator
    /// </summary>
    /// <inheritdoc />
    public class AppleCurator : Resource<AppleCuratorAttributes, AppleCuratorRelationships>
    {
        /// <summary>
        /// (Required) This value will always be appleCurators.
        /// Value: appleCurators
        /// </summary>
        public override string Type => Constants.Resources.AppleCurators;
    }
}
