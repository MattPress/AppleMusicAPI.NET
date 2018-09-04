using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum RecommendationsType
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "playlists")]
        Playlists
    }
}