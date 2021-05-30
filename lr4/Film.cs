namespace lr4
{
    class Film
    {
        public string Name { get; }
        public FilmGenre Genre { get; }

        public Film(string name, FilmGenre genre)
        {
            Name = name;
            Genre = genre;
        }
    }
}
