using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum ContentRating
    {
        [EnumMember(Value = "")]
        None,
        Clean,
        Explicit
    }
}