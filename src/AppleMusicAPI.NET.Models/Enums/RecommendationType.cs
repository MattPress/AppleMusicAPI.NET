using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum RecommendationType
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "playlists")]
        Playlists
    }
}