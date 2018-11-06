
using System.Collections.Generic;

namespace AppleMusicAPI.NET.Models.Core
{
    /// <typeparam name="TResource"></typeparam>
    /// <inheritdoc />
    public class Relationship<TResource> : RelationshipRoot
        where TResource : IResource
    {
        /// <summary>
        /// One or more destination objects.
        /// </summary>
        public List<TResource> Data { get; set; }
    }
}
