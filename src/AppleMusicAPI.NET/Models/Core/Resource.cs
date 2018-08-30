
namespace AppleMusicAPI.NET.Models.Core
{
    /// <summary>
    /// A resource—such as an album, song, or playlist—in the Apple Music catalog or iCloud Music Library.
    /// https://developer.apple.com/documentation/applemusicapi/resource
    /// </summary>
    public abstract class Resource : IResource
    {
        /// <summary>
        /// A URL subpath that fetches the resource as the primary object. This member is only present in responses.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// (Required) Persistent identifier of the resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// (Required) The type of resource.
        /// </summary>
        public abstract string Type { get; }

        // TODO - MJP - Need a solution for serializing this. Find out content structure.
        /// <summary>
        /// Information about the request or response. The members may be any of the endpoint parameters.
        /// </summary>
        public object Meta { get; set; }
    }
}
