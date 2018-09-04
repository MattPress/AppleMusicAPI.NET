using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a genre object.
    /// https://developer.apple.com/documentation/applemusicapi/genre/attributes
    /// </summary>
    public class GenreAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The localized name of the genre.
        /// </summary>
        public string Name { get; set; }
    }
}
