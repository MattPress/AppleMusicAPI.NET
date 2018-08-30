using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Enums
{
    public enum ContentRating
    {
        [EnumMember(Value = "")]
        None,
        Clean,
        Explicit
    }
}