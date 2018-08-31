using System.Collections.Generic;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for an artist object.
    /// https://developer.apple.com/documentation/applemusicapi/artist/attributes
    /// </summary>
    public class ArtistAttributes : IAttributes
    {
        /// <summary>
        /// The notes about the artist that appear in the iTunes Store.
        /// </summary>
        public EditorialNotes EditorialNotes { get; set; }

        /// <summary>
        /// (Required) The names of the genres associated with this artist.
        /// </summary>
        public List<string> GenreNames { get; set; }

        /// <summary>
        /// (Required) The localized name of the artist.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required) The URL for sharing an artist in the iTunes Store.
        /// </summary>
        public string Url { get; set; }
    }
}
