using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum ResourceType
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "music-videos")]
        MusicVideos,
        [EnumMember(Value = "")]
        Playlists,
        [EnumMember(Value = "")]
        Songs,
        [EnumMember(Value = "")]
        Stations
    }
}