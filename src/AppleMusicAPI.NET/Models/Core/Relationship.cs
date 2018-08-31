
namespace AppleMusicAPI.NET.Models.Core
{
    /// <summary>
    /// A to-one or to-many relationship from one resource object to others.
    /// https://developer.apple.com/documentation/applemusicapi/relationship
    /// </summary>
    public abstract class Relationship : RelationshipRoot<ResourceRoot>
    {
    }
}
