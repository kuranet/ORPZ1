﻿using System.Collections.Generic;

namespace lr4
{
    class Cinema
    {
        private List<Film> _showedFilms = new List<Film>();

        public int Id { get; }
        public string Name { get; }
        public CinemaRank Rank { get; }
        public long PlaceCapacity { get; }
        public int BuildYear { get; }
        public List<Film> ShowedFilms => _showedFilms;

        public Cinema(int id, string name, CinemaRank rank, long placeCapacity, int buildYear)
        {
            Id = id;
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
