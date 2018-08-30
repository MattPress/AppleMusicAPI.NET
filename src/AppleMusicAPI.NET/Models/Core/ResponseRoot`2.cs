
namespace AppleMusicAPI.NET.Models.Core
{
    /// <inheritdoc />
    /// <typeparam name="TResource"></typeparam>
    /// <typeparam name="TResults"></typeparam>
    public class ResponseRoot<TResource, TResults> : ResponseRoot<TResource>
        where TResource : IResource
        where TResults : IResults
    {
        /// <summary>
        /// The results of the operation. If there are results, the object contains contents; otherwise, it is empty or null.
        /// </summary>
        public new TResults Results { get; set; }
    }
}
