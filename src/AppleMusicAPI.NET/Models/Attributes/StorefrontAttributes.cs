using System.Collections.Generic;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a storefront object.
    /// https://developer.apple.com/documentation/applemusicapi/storefront/attributes
    /// </summary>
    public class StorefrontAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The default language for the storefront, represented as a language tag.
        /// </summary>
        public string DefaultLanguageTag { get; set; }

        /// <summary>
        /// (Required) The localized name of the storefront.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required) The localizations that the storefront supports, represented as an array of language tags.
        /// </summary>
        public List<string> SupportedLanguageTags { get; set; }
    }
}
