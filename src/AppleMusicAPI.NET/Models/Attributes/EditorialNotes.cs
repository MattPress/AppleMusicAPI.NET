
namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// An object that represents notes.
    /// https://developer.apple.com/documentation/applemusicapi/editorialnotes
    /// </summary>
    public class EditorialNotes
    {
        /// <summary>
        /// (Required) Notes shown when the content is prominently displayed.
        /// </summary>
        public string Short { get; set; }

        /// <summary>
        /// (Required) Abbreviated notes shown inline or when the content is shown alongside other content.
        /// </summary>
        public string Standard { get; set; }
    }
}
