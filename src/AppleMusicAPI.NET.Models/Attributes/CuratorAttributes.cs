using System;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a curator object.
    /// https://developer.apple.com/documentation/applemusicapi/curator/attributes
    /// </summary>
    public class CuratorAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The curator artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The notes about the curator.
        /// </summary>
        public EditorialNotes EditorialNotes { get; set; }

        /// <summary>
        /// (Required) The localized name of the curator.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required) The URL for sharing a curator in Apple Music.
        /// </summary>
        public Uri Url { get; set; }
    }
}
