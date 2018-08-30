using System.Collections.Generic;
using System.Linq;

namespace AppleMusicAPI.NET.Models.Core
{
    /// <summary>
    /// A to-one or to-many relationship from one resource object to others.
    /// https://developer.apple.com/documentation/applemusicapi/relationship
    /// </summary>
    public class Relationship
    {
        /// <summary>
        /// One or more destination objects.
        /// </summary>
        public Resource[] Data { get; set; }

        /// <summary>
        /// A URL subpath that fetches the resource as the primary object. This member is only present in responses.
        /// </summary>
        public string Href { get; set; }

        // TODO - MJP - figure out meta schema
        /// <summary>
        /// Information about the request or response. The members may be any of the endpoint parameters.
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// Link to the next page of resources in the relationship. Contains the offset query parameter that specifies the next page. See Fetch Resources by Page.
        /// </summary>
        public string Next { get; set; }

        protected List<T> GetDataOfType<T>()
        {
            return (Data ?? new Resource[0])
                .OfType<T>()
                .ToList();
        }
    }
}
