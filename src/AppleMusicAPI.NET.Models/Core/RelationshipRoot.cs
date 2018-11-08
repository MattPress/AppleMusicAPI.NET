
using Newtonsoft.Json.Linq;

namespace AppleMusicAPI.NET.Models.Core
{
    public abstract class RelationshipRoot
    {
        /// <summary>
        /// A URL subpath that fetches the resource as the primary object. This member is only present in responses.
        /// </summary>
        public string Href { get; set; }

        // TODO - MJP - figure out meta schema
        /// <summary>
        /// Information about the request or response. The members may be any of the endpoint parameters.
        /// </summary>
        public JToken Meta { get; set; }

        /// <summary>
        /// Link to the next page of resources in the relationship. Contains the offset query parameter that specifies the next page. See Fetch Resources by Page.
        /// </summary>
        public string Next { get; set; }
    }
}
