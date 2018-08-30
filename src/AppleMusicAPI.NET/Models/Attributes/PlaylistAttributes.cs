using System;
using AppleMusicAPI.NET.Enums;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a playlist object.
    /// https://developer.apple.com/documentation/applemusicapi/playlist/attributes
    /// </summary>
    public class PlaylistAttributes : IAttributes
    {
        /// <summary>
        /// The playlist artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The display name of the curator.
        /// </summary>
        public string CuratorName { get; set; }

        /// <summary>
        /// A description of the playlist.
        /// </summary>
        public EditorialNotes Description { get; set; }

        /// <summary>
        /// (Required) The date the playlist was last modified.
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// (Required) The localized name of the album.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters to use to play back the tracks in the playlist.
        /// </summary>
        public PlayParameters PlayParams { get; set; }

        /// <summary>
        /// (Required) The type of playlist.
        /// </summary>
        public PlaylistType PlaylistType { get; set; }

        /// <summary>
        /// (Required) The URL for sharing an album in the iTunes Store.
        /// </summary>
        public string Url { get; set; }
    }
}
