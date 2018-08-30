using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a library artist object.
    /// https://developer.apple.com/documentation/applemusicapi/libraryartist/attributes
    /// </summary>
    public class LibraryArtistAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The artist’s name.
        /// </summary>
        public string Name { get; set; }
    }
}
