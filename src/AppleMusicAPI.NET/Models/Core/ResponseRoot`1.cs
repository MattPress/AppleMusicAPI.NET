
namespace AppleMusicAPI.NET.Models.Core
{
    /// <summary>
    /// The JSON root object contained in every response.
    /// https://developer.apple.com/documentation/applemusicapi/responseroot
    /// </summary>
    public abstract class ResponseRoot<TResource>
        where TResource : IResource
    {
        /// <summary>
        /// The primary data for a request or response. If data exists, this property is an array of one or more resource objects. If no data exists, this property is an empty array or null.
        /// </summary>
        public TResource[] Data { get; set; }

        /// <summary>
        /// An array of one or more errors that occurred while executing the operation.
        /// </summary>
        public Error[] Errors { get; set; }

        /// <summary>
        /// A link to the request that generated the response data or results; not present in a request.
        /// </summary>
        public string Href { get; set; }

        // TODO - MJP - Figure out schema
        /// <summary>
        /// Information about the request or response. The members may be any of the endpoint parameters.
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// A link to the next page of data or results; contains the offset query parameter that specifies the next page. See Fetch Resources by Page.
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// The results of the operation. If there are results, the object contains contents; otherwise, it is empty or null.
        /// </summary>
        public IResults Results { get; set; }
    }
}
