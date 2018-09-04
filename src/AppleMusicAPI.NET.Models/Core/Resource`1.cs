
namespace AppleMusicAPI.NET.Models.Core
{
    /// <typeparam name="TAttributes"></typeparam>
    /// <inheritdoc />
    public abstract class Resource<TAttributes> : ResourceRoot
        where TAttributes : IAttributes
    {
        /// <summary>
        /// Attributes belonging to the resource (can be a subset of the attributes). The members are the names of the attributes defined in the object model.
        /// </summary>
        public TAttributes Attributes { get; set; }
    }
}
