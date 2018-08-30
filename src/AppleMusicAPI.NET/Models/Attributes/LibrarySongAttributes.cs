using AppleMusicAPI.NET.Enums;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a library song object.
    /// https://developer.apple.com/documentation/applemusicapi/librarysong/attributes
    /// </summary>
    public class LibrarySongAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The name of the album the song appears on.
        /// </summary>
        public string AlbumName { get; set; }

        /// <summary>
        /// (Required) The artist’s name.
        /// </summary>
        public string ArtistName { get; set; }

        /// <summary>
        /// (Required) The album artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The Recording Industry Association of America (RIAA) rating of the content. The possible values for this rating are clean and explicit. No value means no rating.
        /// </summary>
        public ContentRating ContentRating { get; set; }

        /// <summary>
        /// (Required) The disc number the song appears on.
        /// </summary>
        public int DiscNumber { get; set; }

        /// <summary>
        /// The approximate length of the song in milliseconds.
        /// </summary>
        public long DurationInMillis { get; set; }

        /// <summary>
        /// (Required) The localized name of the song.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters to use to playback the song.
        /// </summary>
        public PlayParameters PlayParams { get; set; }

        /// <summary>
        /// (Required) The number of the song in the album’s track list.
        /// </summary>
        public int TrackNumber { get; set; }
    }
}
