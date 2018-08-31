
namespace AppleMusicAPI.NET.Models.Core
{
    /// <inheritdoc />
    /// <typeparam name="TResults"></typeparam>
    public abstract class SearchResponseRoot<TResults> : ResponseRoot
        where TResults : IResults
    {
        /// <summary>
        /// The results of the operation. If there are results, the object contains contents; otherwise, it is empty or null.
        /// </summary>
        public TResults Results { get; set; }
    }
}
