using System;
using System.Collections.Generic;
using System.Text;

namespace lr5
{
    class Cinema
    {
        public string Name { get; }
        public CinemaRank Rank { get; }
        public long PlaceCapacity { get; }
        public int BuildYear { get; }

        public Cinema(string name, CinemaRank rank, long placeCapacity, int buildYear)
        {
            Name = name;
            Rank = rank;
            PlaceCapacity = placeCapacity;
            BuildYear = buildYear;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Rank: {Rank}, Capacity: {PlaceCapacity}, Build year: {BuildYear}";
        }
    }
}
