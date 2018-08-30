using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a curator of resources.
    /// https://developer.apple.com/documentation/applemusicapi/curator
    /// </summary>
    /// <inheritdoc />
    public class Curator : Resource<CuratorAttributes, CuratorRelationships>
    {
        /// <summary>
        /// (Required) This value will always be curators. Value: curators
        /// </summary>
        public override string Type => Constants.Resources.Curators;
    }
}
