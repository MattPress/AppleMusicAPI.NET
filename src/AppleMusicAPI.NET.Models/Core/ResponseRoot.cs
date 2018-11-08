
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace AppleMusicAPI.NET.Models.Core
{
    public class ResponseRoot
    {
        /// <summary>
        /// An array of one or more errors that occurred while executing the operation.
        /// </summary>
        public List<Error> Errors { get; set; }

        /// <summary>
        /// A link to the request that generated the response data or results; not present in a request.
        /// </summary>
        public string Href { get; set; }

        // TODO - MJP - Figure out schema
        /// <summary>
        /// Information about the request or response. The members may be any of the endpoint parameters.
        /// </summary>
        public JToken Meta { get; set; }

        /// <summary>
        /// A link to the next page of data or results; contains the offset query parameter that specifies the next page. See Fetch Resources by Page.
        /// </summary>
        public string Next { get; set; }
    }
}
