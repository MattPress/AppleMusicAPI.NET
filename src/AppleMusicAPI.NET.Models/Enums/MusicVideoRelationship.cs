using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum MusicVideoRelationship
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "artists")]
        Artists,
        [EnumMember(Value = "genres")]
        Genres
    }
}