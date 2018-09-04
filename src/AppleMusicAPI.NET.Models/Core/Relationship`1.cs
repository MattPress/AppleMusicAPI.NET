
namespace AppleMusicAPI.NET.Models.Core
{
    /// <typeparam name="TResource"></typeparam>
    /// <inheritdoc />
    public class Relationship<TResource> : RelationshipRoot<TResource>
        where TResource : IResource
    {
    }
}
