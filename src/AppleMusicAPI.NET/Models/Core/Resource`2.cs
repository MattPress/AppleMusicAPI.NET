
namespace AppleMusicAPI.NET.Models.Core
{
    /// <typeparam name="TAttributes"></typeparam>
    /// <typeparam name="TRelationships"></typeparam>
    /// <inheritdoc />
    public abstract class Resource<TAttributes, TRelationships> : Resource<TAttributes>
        where TAttributes : IAttributes
        where TRelationships : IRelationships
    {
        /// <summary>
        /// Relationships belonging to the resource (can be a subset of the relationships). The members are the names of the relationships defined in the object model. See Relationship object for the values of the members.
        /// </summary>
        public TRelationships Relationships { get; set; }
    }
}
