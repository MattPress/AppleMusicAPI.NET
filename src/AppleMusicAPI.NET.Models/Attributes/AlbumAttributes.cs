using System;
using System.Collections.Generic;
using AppleMusicAPI.NET.Enums;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for an album object.
    /// https://developer.apple.com/documentation/applemusicapi/album/attributes
    /// </summary>
    public class AlbumAttributes : IAttributes
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
        /// The album artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The Recording Industry Association of America (RIAA) rating of the content. The possible values for this rating are clean and explicit. No value means no rating.
        /// </summary>
        public ContentRating ContentRating { get; set; }

        /// <summary>
        /// The copyright text.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// The notes about the album that appear in the iTunes Store.
        /// </summary>
        public EditorialNotes EditorialNotes { get; set; }

        /// <summary>
        /// (Required) The names of the genres associated with this album.
        /// </summary>
        public List<string> GenreNames { get; set; }

        /// <summary>
        /// (Required) Indicates whether the album is complete. If true, the album is complete; otherwise, it is not. An album is complete if it contains all its tracks and songs.
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// (Required) Indicates whether the album contains a single song.
        /// </summary>
        public bool IsSingle { get; set; }

        /// <summary>
        /// (Required) The localized name of the album.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters to use to play back the tracks of the album.
        /// </summary>
        public PlayParameters PlayParams { get; set; }

        /// <summary>
        /// (Required) The name of the record label for the album.
        /// </summary>
        public string RecordLabel { get; set; }

        /// <summary>
        /// (Required) The release date of the album in YYYY-MM-DD format.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// (Required) The number of tracks.
        /// </summary>
        public int TrackCount { get; set; }

        /// <summary>
        /// (Required) The URL for sharing the album in the iTunes Store.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// (Required) Indicates whether the album has been delivered as Mastered for iTunes.
        /// </summary>
        public bool IsMasteredForItunes { get; set; }
    }
}
