using System;
using System.Collections;
using System.Linq;

namespace lr4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cinemaController1 = new CinemaController();
            cinemaController1.AddCinema(new Cinema("FirstCinema", CinemaRank.VideoFilm, 150, 1990));
            cinemaController1.AddCinema(new Cinema("Maneskin", CinemaRank.WideScreenFilm, 200, 1866));
            cinemaController1.AddCinema(new Cinema("Ze!", CinemaRank.WideScreenFilm, 15, 2005));
            cinemaController1.AddCinema(new Cinema("Sparta", CinemaRank.StereoFormatFilm, 300, 2012));
            cinemaController1.AddCinema(new Cinema("Cristal", CinemaRank.StereoFormatFilm, 145, 2002));
            cinemaController1.AddCinema(new Cinema("AstraZenak", CinemaRank.VideoFilm, 2, 1987));
            cinemaController1.AddCinema(new Cinema("Aboba", CinemaRank.VideoFilm, 188, 1899));
            cinemaController1.AddCinema(new Cinema("Rocker", CinemaRank.StereoFormatFilm, 47, 2002));
            cinemaController1.AddCinema(new Cinema("Go_A", CinemaRank.StereoFormatFilm, 199, 1999));
            cinemaController1.AddCinema(new Cinema("Poero", CinemaRank.VideoFilm, 80, 2003));
            cinemaController1.AddCinema(new Cinema("Arevoero", CinemaRank.StereoFormatFilm, 33, 2008));
            cinemaController1.AddCinema(new Cinema("AntiCinema", CinemaRank.WideScreenFilm, 150, 1967));

            // Ordering by year. 
            Console.WriteLine("task1");
            var task1 = cinemaController1.Cinemas
                .OrderBy(cinema => cinema.BuildYear);
            PrintSequnce(task1);

            // Sorting long form.
            Console.WriteLine("task2");
            var minYear = 2000;
            var minCapacity = 100;
            var task2 = from x in cinemaController1.Cinemas
                        where x.BuildYear >= minYear && x.PlaceCapacity >= minCapacity
                        select x;
            PrintSequnce(task2);

            // Sorting short form.
            Console.WriteLine("task3");
            var startLetter = 'A';
            var task3 = cinemaController1.Cinemas
                .Where(x => x.Name[0] == startLetter && x.Rank == CinemaRank.VideoFilm);
            PrintSequnce(task3);

            // SkipWhile && TakeWhile
            Console.WriteLine("task4");
            minYear = 2002;
            var maxYear = 2008;
            var task4 = task1.SkipWhile(x => x.BuildYear < minYear)
                .TakeWhile(x => x.BuildYear <= maxYear);
            PrintSequnce(task4);

            // Aggregation.
            Console.WriteLine("task5");
            var task5 = from x in cinemaController1.Cinemas
                        from y in cinemaController1.Cinemas
                        where x != y
                            && x.Rank == y.Rank
                            && cinemaController1.Cinemas.IndexOf(x) < cinemaController1.Cinemas.IndexOf(y)
                        select new { x, y };
            PrintSequnce(task5);

            var cinemaController2 = new CinemaController();
            cinemaController2.AddCinema(new Cinema("FirstCinema", CinemaRank.VideoFilm, 150, 1990));
            cinemaController2.AddCinema(new Cinema("Maneskin", CinemaRank.WideScreenFilm, 200, 1866));
            cinemaController2.AddCinema(new Cinema("Maneskin", CinemaRank.WideScreenFilm, 200, 1866));
            cinemaController2.AddCinema(new Cinema("Maneskin", CinemaRank.WideScreenFilm, 200, 1866));
            cinemaController2.AddCinema(new Cinema("Lokero", CinemaRank.WideScreenFilm, 200, 1866));
            cinemaController2.AddCinema(new Cinema("Sparta", CinemaRank.StereoFormatFilm, 300, 2012));
            cinemaController2.AddCinema(new Cinema("AstraZenak", CinemaRank.VideoFilm, 2, 1987));
            cinemaController2.AddCinema(new Cinema("Aboba", CinemaRank.VideoFilm, 188, 1899));
            cinemaController2.AddCinema(new Cinema("Go_A", CinemaRank.StereoFormatFilm, 199, 1999));
            cinemaController2.AddCinema(new Cinema("Poero", CinemaRank.VideoFilm, 80, 2003));

            // Inner join (use where)
            Console.WriteLine("task6");
            var task6 = from x in cinemaController1.Cinemas
                        from y in cinemaController2.Cinemas
                        where x.Name == y.Name
                        select new { x, y };
            PrintSequnce(task6);

            // Inner join(use join)
            Console.WriteLine("task7");
            var task7 = from x in cinemaController1.Cinemas
                        join y in cinemaController2.Cinemas on x.Name equals y.Name
                        select new { x, y };
            PrintSequnce(task7);

            // Cross Join && Group Join
            Console.WriteLine("task8");
            var task8 = from x in cinemaController1.Cinemas
                        join y in cinemaController2.Cinemas on x.Name equals y.Name into temp
                        from t in temp
                        select new { v1 = x.Name, v2 = t.Name, cnt = temp.Count() };
            PrintSequnce(task8);

            // Disticntion.
            Console.WriteLine("task9");
            var task9 = task8.Distinct();
            PrintSequnce(task9);

            // To dictionary.
            Console.WriteLine("task10");
            var task10 = (from x in cinemaController1.Cinemas
                          join y in cinemaController2.Cinemas on x.Name equals y.Name into temp
                          from t in temp
                          select new { v1 = x.Name, cnt = temp.Count() })
                         .Distinct().ToDictionary(x => x.v1);
            PrintSequnce(task10);

            // Union
            Console.WriteLine("task11");
            var names1 = cinemaController1.Cinemas.Select(x => x.Name);
            var names2 = cinemaController2.Cinemas.Select(x => x.Name);
            var task11 = names1.Union(names2);
            PrintSequnce(task11);
        }

        private static void PrintSequnce(IEnumerable enumarable)
        {
            foreach (var x in enumarable)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }
    }
}
