using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppleMusicAPI.NET.Models.Results
{
    /// <summary>
    /// A Resource object that represents a chart, or a collection of the top songs, albums, or other types of resources.
    /// https://developer.apple.com/documentation/applemusicapi/chart
    /// </summary>
    public class Chart<TResource>
    {
        /// <summary>
        /// (Required) The chart identifier.
        /// </summary>
        [JsonProperty("chart")]
        public string ChartId { get; set; }

        /// <summary>
        /// (Required) An array of the requested objects, ordered by popularity. For example, if songs were specified as the chart type in the request, the array contains Song objects.
        /// </summary>
        public List<TResource> Data { get; set; }

        /// <summary>
        /// (Required) The URL for the chart.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// (Required) The localized name for the chart.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL for the next page.
        /// </summary>
        public string Next { get; set; }
    }
}
