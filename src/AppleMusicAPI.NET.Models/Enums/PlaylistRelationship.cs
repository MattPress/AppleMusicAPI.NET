using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum PlaylistRelationship
    {
        [EnumMember(Value = "curator")]
        Curator,
        [EnumMember(Value = "tracks")]
        Tracks
    }
}