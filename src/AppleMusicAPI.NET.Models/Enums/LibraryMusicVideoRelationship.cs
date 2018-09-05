using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum LibraryMusicVideoRelationship
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "artists")]
        Artists
    }
}