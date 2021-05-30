using System;
using System.Collections;
using System.Linq;

namespace lr4
{
    /// <summary>
    /// Розробити структуру даних для зберігання інформації про кінотеатри міста. 
    /// Для кінотеатру зберігається інформація: найменування кінотеатру, місткість 
    /// (кількість місць), рік побудови, ранг кінотеатру (для перегляду відеофільмів, 
    /// для перегляду широкоформатних фільмів, наявність стереоформатного обладнання, тощо).
    /// </summary>
    
    class Program
    {
        static void Main(string[] args)
        {
            var cinemaController1 = new CinemaController();
            cinemaController1.AddCinema(new Cinema(1, "FirstCinema", CinemaRank.VideoFilm, 150, 1990));
            cinemaController1.AddCinema(new Cinema(2, "Maneskin", CinemaRank.WideScreenFilm, 200, 1866));
            cinemaController1.AddCinema(new Cinema(3, "Ze!", CinemaRank.WideScreenFilm, 15, 2005));
            cinemaController1.AddCinema(new Cinema(4, "Sparta", CinemaRank.StereoFormatFilm, 300, 2012));
            cinemaController1.AddCinema(new Cinema(5, "Cristal", CinemaRank.StereoFormatFilm, 145, 2002));
            cinemaController1.AddCinema(new Cinema(6, "AstraZenak", CinemaRank.VideoFilm, 2, 1987));
            cinemaController1.AddCinema(new Cinema(7, "Aboba", CinemaRank.VideoFilm, 188, 1899));
            cinemaController1.AddCinema(new Cinema(8, "Rocker", CinemaRank.StereoFormatFilm, 47, 2002));
            cinemaController1.AddCinema(new Cinema(9, "Go_A", CinemaRank.StereoFormatFilm, 199, 1999));
            cinemaController1.AddCinema(new Cinema(10, "Poero", CinemaRank.VideoFilm, 80, 2003));
            cinemaController1.AddCinema(new Cinema(11, "Arevoero", CinemaRank.StereoFormatFilm, 33, 2008));
            cinemaController1.AddCinema(new Cinema(12, "AntiCinema", CinemaRank.WideScreenFilm, 150, 1967));

            // Ordering by year. 
            Console.WriteLine("1. order by build year");
            var task1 = cinemaController1.Cinemas
                .OrderBy(cinema => cinema.BuildYear);
            PrintSequnce(task1);

            // Sorting long form.
            Console.WriteLine("2. sorting, get cinemas builet after 2000 with capacity >= 100");
            var minYear = 2000;
            var minCapacity = 100;
            var task2 = from x in cinemaController1.Cinemas
                        where x.BuildYear >= minYear && x.PlaceCapacity >= minCapacity
                        select x;
            PrintSequnce(task2);

            // Sorting short form.
            Console.WriteLine("3. sorting, get cinemas, which name starts with 'A' and its rank is VideoFilm");
            var startLetter = 'A';
            var task3 = cinemaController1.Cinemas
                .Where(x => x.Name[0] == startLetter && x.Rank == CinemaRank.VideoFilm);
            PrintSequnce(task3);

            // SkipWhile && TakeWhile
            Console.WriteLine("4. skipwhile && takewhile");
            minYear = 2002;
            var maxYear = 2008;
            var task4 = task1.SkipWhile(x => x.BuildYear < minYear)
                .TakeWhile(x => x.BuildYear <= maxYear);
            PrintSequnce(task4);

            // Aggregation.
            Console.WriteLine("5.");
            var task5 = from x in cinemaController1.Cinemas
                        from y in cinemaController1.Cinemas
                        where x != y
                            && x.Rank == y.Rank
                            && cinemaController1.Cinemas.IndexOf(x) < cinemaController1.Cinemas.IndexOf(y)
                        select new { x, y };
            PrintSequnce(task5);

            var cinemaController2 = new CinemaController();
            cinemaController2.AddCinema(new Cinema(1, "FirstCinema", CinemaRank.VideoFilm, 210, 1990));
            cinemaController2.AddCinema(new Cinema(2, "Maneskin", CinemaRank.WideScreenFilm, 400, 1866));
            cinemaController2.AddCinema(new Cinema(3, "Maneskin", CinemaRank.WideScreenFilm, 400, 1866));
            cinemaController2.AddCinema(new Cinema(4, "Maneskin", CinemaRank.WideScreenFilm, 400, 1866));
            cinemaController2.AddCinema(new Cinema(5, "Lokero", CinemaRank.WideScreenFilm, 400, 1866));
            cinemaController2.AddCinema(new Cinema(6, "Sparta", CinemaRank.StereoFormatFilm, 300, 2012));
            cinemaController2.AddCinema(new Cinema(7, "AstraZenak", CinemaRank.VideoFilm, 2, 1987));
            cinemaController2.AddCinema(new Cinema(8, "Aboba", CinemaRank.VideoFilm, 350, 1899));
            cinemaController2.AddCinema(new Cinema(9, "Go_A", CinemaRank.StereoFormatFilm, 199, 1999));
            cinemaController2.AddCinema(new Cinema(10, "Poero", CinemaRank.VideoFilm, 80, 2003));

            // Inner join (use where)
            Console.WriteLine("6. inner join (use where)");
            var task6 = from x in cinemaController1.Cinemas
                        from y in cinemaController2.Cinemas
                        where x.Id == y.Id
                        select new { x, y };
            PrintSequnce(task6);

            // Inner join(use join)
            Console.WriteLine("7. inner join (use join)");
            var task7 = from x in cinemaController1.Cinemas
                        join y in cinemaController2.Cinemas on x.Id equals y.Id
                        select new { x, y };
            PrintSequnce(task7);

            Console.WriteLine("8. Left join"); 
            var task8 = from x in cinemaController1.Cinemas
                      join y in cinemaController2.Cinemas on x.Id equals y.Id into temp 
                      from t in temp.DefaultIfEmpty() 
                      select new { v1 = x.Name, v2 = ((t == null) ? "null" : t.Name) };
            PrintSequnce(task8);

            // Cross Join && Group Join
            Console.WriteLine("9. cross && group join");
            var task9 = from x in cinemaController1.Cinemas
                        join y in cinemaController2.Cinemas on x.Name equals y.Name into temp
                        from t in temp
                        select new { v1 = x.Name, v2 = t.Name, cnt = temp.Count() };
            PrintSequnce(task9);

            // Disticntion.
            Console.WriteLine("10. distinct");
            var task10 = task9.Distinct();
            PrintSequnce(task10);

            // To dictionary.
            Console.WriteLine("11. to dictionary");
            var task11 = (from x in cinemaController1.Cinemas
                          join y in cinemaController2.Cinemas on x.Name equals y.Name into temp
                          from t in temp
                          select new { v1 = x.Name, cnt = temp.Count() })
                         .Distinct()
                         .ToDictionary(x => x.v1);
            PrintSequnce(task11);

            // Union
            Console.WriteLine("12. names1 union names2");
            var names1 = cinemaController1.Cinemas.Select(x => x.Name);
            var names2 = cinemaController2.Cinemas.Select(x => x.Name);
            var task12 = names1.Union(names2);
            PrintSequnce(task12);

            // Intersect
            Console.WriteLine("13. names1 intersect names2");
            var task13 = names1.Intersect(names2);
            PrintSequnce(task13);

            // Except
            Console.WriteLine("14. names1 except names2");
            var task14 = names1.Except(names2);
            PrintSequnce(task14);

            // Group
            Console.WriteLine("15. group any");
            var task15 = from x in cinemaController1.Cinemas.Union(cinemaController2.Cinemas)
                         group x by x.Name into g
                         where g.Any(x => x.PlaceCapacity > 200)
                         select new { Key = g.Key, Values = g };
            foreach (var x in task15)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }
            Console.WriteLine();

            // Group
            Console.WriteLine("16. group all");
            var task16 = from x in cinemaController1.Cinemas.Union(cinemaController2.Cinemas)
                         group x by x.Name into g
                         where g.All(x => x.PlaceCapacity > 200)
                         select new { Key = g.Key, Values = g };
            foreach (var x in task16)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }
            Console.WriteLine();
        }

        private static void PrintSequnce(IEnumerable enumarable)
        {
            foreach (var x in enumarable)
            {
                Console.Write("\t");
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }
    }
}
