
namespace AppleMusicAPI.NET.Models.Core
{
    /// <summary>
    /// The paging options which will be added to the query string of paged requests.
    /// </summary>
    public class PageOptions
    {
        /// <summary>
        /// The limit on the number of objects, or number of objects in the specified relationship, that are returned.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The next page or group of objects to fetch. See Fetch Resources by Page.
        /// </summary>
        public int? Offset { get; set; }
    }
}
