using AppleMusicAPI.NET.Models.Resources;

namespace AppleMusicAPI.NET.Models.Responses
{
    /// <summary>
    /// The response to a chart request.
    /// https://developer.apple.com/documentation/applemusicapi/chartresponse
    /// </summary>
    public class ChartResponse
    {
        /// <summary>
        /// The albums returned when fetching charts.
        /// </summary>
        public Chart<Album> Albums { get; set; }

        /// <summary>
        /// The music videos returned when fetching charts.
        /// </summary>
        public Chart<MusicVideo> MusicVideos { get; set; }

        /// <summary>
        /// The songs returned when fetching charts.
        /// </summary>
        public Chart<Song> Songs { get; set; }
    }
}
