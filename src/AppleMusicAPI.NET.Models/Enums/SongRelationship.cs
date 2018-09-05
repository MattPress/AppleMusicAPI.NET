using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum SongRelationship
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "artists")]
        Artists,
        [EnumMember(Value = "genres")]
        Genres,
        [EnumMember(Value = "station")]
        Station
    }
}