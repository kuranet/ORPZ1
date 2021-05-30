using System.Collections.Generic;

namespace lr5
{
    class CinemaController
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();
        public List<Cinema> Cinemas => _cinemas;

        public void AddCinema(Cinema cinema)
        {
            _cinemas.Add(cinema);
        }

        public void RemoveCinema(Cinema cinema)
        {
            _cinemas.Remove(cinema);
        }
    }
}
