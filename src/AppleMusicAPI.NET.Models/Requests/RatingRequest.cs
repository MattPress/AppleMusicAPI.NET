using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Attributes;

namespace AppleMusicAPI.NET.Models.Requests
{
    public class RatingRequest
    {
        public RatingAttributes Attributes { get; set; }

        public string Type => "rating";
    }
}
