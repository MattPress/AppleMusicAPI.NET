
namespace AppleMusicAPI.NET.Models.Core
{
    /// <typeparam name="TResource"></typeparam>
    /// <inheritdoc />
    public class Relationship<TResource> : Relationship
        where TResource : IResource
    {
        /// <summary>
        /// One or more destination objects.
        /// </summary>
        public new TResource[] Data { get; set; }
    }
}
