using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a library playlist object.
    /// https://developer.apple.com/documentation/applemusicapi/libraryplaylist/attributes
    /// </summary>
    public class LibraryPlaylistAttributes : IAttributes
    {
        /// <summary>
        /// The playlist artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// A description of the playlist.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// (Required) The localized name of the album.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters to use to play back the tracks in the playlist.
        /// </summary>
        public PlayParameters PlayParams { get; set; }

        /// <summary>
        /// (Required) Indicates whether the playlist can be edited.
        /// </summary>
        public bool CanEdit { get; set; }
    }
}
