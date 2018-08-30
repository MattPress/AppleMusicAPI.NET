using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Resources;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// An object that represents the track relationship for a Resource object.
    /// https://developer.apple.com/documentation/applemusicapi/trackrelationship
    /// </summary>
    // TODO - MJP - Need to figure out how to serialize both Song and Music Video resources into the data array. 
    public class TrackRelationship : Relationship
    {
    }
}
