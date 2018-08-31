
using System.Collections.Generic;

namespace AppleMusicAPI.NET.Models.Core
{
    /// <summary>
    /// The JSON root object contained in every response.
    /// https://developer.apple.com/documentation/applemusicapi/responseroot
    /// </summary>
    public abstract class DataResponseRoot<TResource> : ResponseRoot
        where TResource : IResource
    {
        /// <summary>
        /// The primary data for a request or response. If data exists, this property is an array of one or more resource objects. If no data exists, this property is an empty array or null.
        /// </summary>
        public List<TResource> Data { get; set; }
    }
}
