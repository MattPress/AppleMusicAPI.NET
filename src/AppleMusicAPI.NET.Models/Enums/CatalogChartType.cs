using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum CatalogChartType
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "music-videos")]
        MusicVideos,
        [EnumMember(Value = "songs")]
        Songs
    }
}