using System.Collections.Generic;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;
using Newtonsoft.Json;

namespace AppleMusicAPI.NET.Models.Results
{
    /// <summary>
    /// An object that represents the results of a catalog search query.
    /// https://developer.apple.com/documentation/applemusicapi/searchresults
    /// </summary>
    public class SearchResults : IResults
    {
        /// <summary>
        /// The activities returned for the search query.
        /// </summary>
        public List<ActivityResponse> Activities { get; set; }

        /// <summary>
        /// The albums returned for the search query.
        /// </summary>
        public List<AlbumResponse> Albums { get; set; }

        /// <summary>
        /// The Apple curators returned for the search query.
        /// </summary>
        [JsonProperty("apple-curators")]
        public List<AppleCuratorResponse> AppleCurators { get; set; }

        /// <summary>
        /// The artists returned for the search query.
        /// </summary>
        public List<ArtistResponse> Artists { get; set; }

        /// <summary>
        /// The curators returned for the search query.
        /// </summary>
        public List<CuratorResponse> Curators { get; set; }

        /// <summary>
        /// The music videos returned for the search query.
        /// </summary>
        [JsonProperty("music-videos")]
        public List<MusicVideoResponse> MusicVideos { get; set; }

        /// <summary>
        /// The playlists returned for the search query.
        /// </summary>
        public List<PlaylistResponse> Playlists { get; set; }

        /// <summary>
        /// The songs returned for the search query.
        /// </summary>
        public List<SongResponse> Songs { get; set; }

        /// <summary>
        /// The stations returned for the search query.
        /// </summary>
        public List<StationResponse> Stations { get; set; }
    }
}
