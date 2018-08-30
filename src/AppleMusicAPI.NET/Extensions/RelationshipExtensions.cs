using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Enums;

namespace AppleMusicAPI.NET.Extensions
{
    public static class RelationshipExtensions
    {
        public static string ToRelationshipString(this Relationship relationship)
        {
            switch (relationship)
            {
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
