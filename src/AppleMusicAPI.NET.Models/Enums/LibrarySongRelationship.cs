using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum LibrarySongRelationship
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "artists")]
        Artists
    }
}