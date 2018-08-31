using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a station object.
    /// https://developer.apple.com/documentation/applemusicapi/station/attributes
    /// </summary>
    public class StationAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The radio station artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The duration of the stream. This value is not emitted for 'live' or programmed stations.
        /// </summary>
        public int DurationInMillis { get; set; }

        /// <summary>
        /// The notes about the station that appear in Apple Music.
        /// </summary>
        public EditorialNotes EditorialNotes { get; set; }

        /// <summary>
        /// The episode number of the station. This value is emitted when the station represents an episode of a show or other content.
        /// </summary>
        public int EpisodeNumber { get; set; }

        /// <summary>
        /// (Required) Whether the station is a live stream.
        /// </summary>
        public bool IsLive { get; set; }

        /// <summary>
        /// (Required) The localized name of the station.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required) The URL for sharing a station in Apple Music.
        /// </summary>
        public string Url { get; set; }
    }
}
