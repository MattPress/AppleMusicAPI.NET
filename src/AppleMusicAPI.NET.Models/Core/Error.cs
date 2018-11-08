
using Newtonsoft.Json.Linq;

namespace AppleMusicAPI.NET.Models.Core
{
    /// <summary>
    /// Information about an error that occurred while processing a request.
    /// https://developer.apple.com/documentation/applemusicapi/error
    /// </summary>
    public class Error
    {
        /// <summary>
        /// (Required) The code for this error. For possible values, see HTTP Status Codes.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A long description of the problem; may be localized.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// (Required) A unique identifier for this occurrence of the error.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A object containing references to the source of the error. For possible members, see Source object.
        /// </summary>
        public JToken Source { get; set; }

        /// <summary>
        /// (Required) The HTTP status code for this problem.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// (Required) A short description of the problem; may be localized.
        /// </summary>
        public string Title { get; set; }
    }
}
