
namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// An object that represents artwork.
    /// https://developer.apple.com/documentation/applemusicapi/artwork
    /// </summary>
    public class Artwork
    {
        /// <summary>
        /// The average background color of the image.
        /// </summary>
        public string BgColor { get; set; }

        /// <summary>
        /// (Required) The maximum height available for the image.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// (Required) The maximum width available for the image.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The primary text color that may be used if the background color is displayed.
        /// </summary>
        public string TextColor1 { get; set; }

        /// <summary>
        /// The secondary text color that may be used if the background color is displayed.
        /// </summary>
        public string TextColor2 { get; set; }

        /// <summary>
        /// The tertiary text color that may be used if the background color is displayed.
        /// </summary>
        public string TextColor3 { get; set; }

        /// <summary>
        /// The final post-tertiary text color that may be used if the background color is displayed.
        /// </summary>
        public string TextColor4 { get; set; }

        /// <summary>
        /// (Required) The URL to request the image asset.
        /// The image filename must be preceded by {w}x{h}, as placeholders for the width and height values as described above (for example, {w}x{h}bb.jpeg).
        /// </summary>
        public string Url { get; set; }
    }
}
