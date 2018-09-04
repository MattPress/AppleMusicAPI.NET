using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum ContentRating
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "clean")]
        Clean,
        [EnumMember(Value = "explicit")]
        Explicit
    }
}