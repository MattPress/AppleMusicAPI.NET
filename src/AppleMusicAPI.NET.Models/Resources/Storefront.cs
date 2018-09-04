using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a storefront, an iTunes Store territory that the content is available in.
    /// https://developer.apple.com/documentation/applemusicapi/storefront
    /// </summary>
    /// <inheritdoc />
    public class Storefront : Resource<StorefrontAttributes>
    {
        /// <summary>
        /// (Required) This value will always be storefronts.
        /// Value: storefronts
        /// </summary>
        public override string Type => Constants.Resources.Storefronts;
    }
}
