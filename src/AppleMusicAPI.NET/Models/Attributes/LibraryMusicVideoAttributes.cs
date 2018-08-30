using AppleMusicAPI.NET.Enums;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a library music video object.
    /// https://developer.apple.com/documentation/applemusicapi/librarymusicvideo/attributes
    /// </summary>
    public class LibraryMusicVideoAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The name of the album the music video appears on.
        /// </summary>
        public string AlbumName { get; set; }

        /// <summary>
        /// (Required) The artist’s name.
        /// </summary>
        public string ArtistName { get; set; }

        /// <summary>
        /// (Required) The artwork for the music video’s associated album.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The Recording Industry Association of America (RIAA) rating of the content. The possible values for this rating are clean and explicit. No value means no rating.
        /// </summary>
        public ContentRating ContentRating { get; set; }

        /// <summary>
        /// The duration of the music video in milliseconds.
        /// </summary>
        public long DurationInMillis { get; set; }

        /// <summary>
        /// (Required) The localized name of the music video.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters to use to playback the music video.
        /// </summary>
        public PlayParameters PlayParams { get; set; }

        /// <summary>
        /// The number of the music video in the album’s track list.
        /// </summary>
        public int TrackNumber { get; set; }
    }
}
