using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for an Apple curator object.
    /// https://developer.apple.com/documentation/applemusicapi/applecurator/attributes
    /// </summary>
    public class AppleCuratorAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The curator artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The notes about the curator that appear in the iTunes Store.
        /// </summary>
        public EditorialNotes EditorialNotes { get; set; }

        /// <summary>
        /// (Required) The localized name of the curator.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required) The URL for sharing the curator in the iTunes Store.
        /// </summary>
        public string Url { get; set; }
    }
}
