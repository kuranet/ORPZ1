using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace lr4
{
    class CinemaEquletyComparer : IEqualityComparer<Cinema>
    {
        public bool Equals([AllowNull] Cinema x, [AllowNull] Cinema y)
        {
            if (x.Name != y.Name)
            {
                return false;
            }
            if (x.PlaceCapacity != y.PlaceCapacity)
            {
                return false;
            }
            if (x.Rank != y.Rank)
            {
                return false;
            }
            if (x.BuildYear != y.BuildYear)
            {
                return false;
            }
            return true;
        }

        public int GetHashCode([DisallowNull] Cinema obj)
        {
            return obj.Id;
        }
    }
}
