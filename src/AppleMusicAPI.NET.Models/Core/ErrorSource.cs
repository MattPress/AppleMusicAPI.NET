
namespace AppleMusicAPI.NET.Models.Core
{
    /// <summary>
    /// The Source object represents the source of an error.
    /// https://developer.apple.com/documentation/applemusicapi/error/source
    /// </summary>
    public class ErrorSource
    {
        /// <summary>
        /// The URI query parameter that caused the error.
        /// </summary>
        public string Parameter { get; set; }

        // TODO - MJP - Need to figure out schema for JSONPointer.
        /// <summary>
        /// A pointer to the associated entry in the request document.
        /// </summary>
        public object Pointer { get; set; }
    }
}
