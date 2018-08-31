using System;
using System.Collections.Generic;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a music video object.
    /// https://developer.apple.com/documentation/applemusicapi/musicvideo/attributes
    /// </summary>
    public class MusicVideoAttributes : IAttributes
    {
        /// <summary>
        /// The name of the album the music video appears on.
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
        public string ContentRating { get; set; }

        /// <summary>
        /// The duration of the music video in milliseconds.
        /// </summary>
        public long DurationInMillis { get; set; }

        /// <summary>
        /// The editorial notes for the music video.
        /// </summary>
        public EditorialNotes EditorialNotes { get; set; }

        /// <summary>
        /// (Required) The music video’s associated genres.
        /// </summary>
        public List<string> GenreNames { get; set; }

        /// <summary>
        /// (Required) The International Standard Recording Code (ISRC) for the music video.
        /// </summary>
        public string Isrc { get; set; }

        /// <summary>
        /// (Required) The localized name of the music video.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters to use to play back the music video.
        /// </summary>
        public PlayParameters PlayParams { get; set; }

        /// <summary>
        /// (Required) The preview assets for the music video.
        /// </summary>
        public List<Preview> Previews { get; set; }

        /// <summary>
        /// (Required) The release date of the music video in YYYY-MM-DD format.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// The number of the music video in the album’s track list.
        /// </summary>
        public int TrackNumber { get; set; }

        /// <summary>
        /// (Required) A URL for sharing the music video.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The video subtype associated with the content.
        /// </summary>
        public string VideoSubType { get; set; }

        /// <summary>
        /// (Required) Whether the music video has HDR10-encoded content.
        /// </summary>
        public bool HasHdr { get; set; }

        /// <summary>
        /// (Required) Whether the music video has 4K content.
        /// </summary>
        public bool Has4K { get; set; }
    }
}
