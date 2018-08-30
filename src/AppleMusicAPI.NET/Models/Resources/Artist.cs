using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Relationships;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents an artist of an album where an artist can be one or more persons.
    /// https://developer.apple.com/documentation/applemusicapi/artist
    /// </summary>
    /// <inheritdoc />
    public class Artist : Resource<ArtistAttributes, ArtistRelationships>
    {
        /// <summary>
        /// (Required) This value will always be artists.
        /// Value: artists
        /// </summary>
        public override string Type => Constants.Resources.Artists;
    }
}
