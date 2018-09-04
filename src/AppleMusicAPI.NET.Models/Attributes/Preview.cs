
using System;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// An object that represents a preview for resources.
    /// https://developer.apple.com/documentation/applemusicapi/preview
    /// </summary>
    public class Preview
    {
        /// <summary>
        /// The preview artwork for the associated music video.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// (Required) The preview URL for the content.
        /// </summary>
        public Uri Url { get; set; }
    }
}
