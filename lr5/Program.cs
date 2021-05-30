using System;
using System.Collections;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace lr5
{
    class Program
    {
        static void Main(string[] args)
        {
            var cinemaController1 = new CinemaController();
            var input = string.Empty;
            //while (input != "n")
            //{
            //    Console.Write("Cinema name: ");
            //    var name = Console.ReadLine();

            //    var isCorrect = false;
            //    var cinemaRanksCount = 0;
            //    while ((CinemaRank)cinemaRanksCount != CinemaRank.TypeCount)
            //    {
            //        Console.WriteLine($"{cinemaRanksCount + 1}. {(CinemaRank)cinemaRanksCount}");
            //        cinemaRanksCount++;
            //    }

            //    var rankInt = 0;
            //    while (isCorrect == false)
            //    {
            //        Console.Write("Cinema rank: ");
            //        if (int.TryParse(Console.ReadLine(), out rankInt) == false || rankInt > cinemaRanksCount || rankInt < 1)
            //        {
            //            Console.WriteLine("Error! Retry!");
            //        }
            //        else
            //        {
            //            isCorrect = true;
            //        }
            //    }

            //    long placeCapacity = 0;
            //    isCorrect = false;
            //    while (isCorrect == false)
            //    {
            //        Console.Write("Cinema place capacity: ");
            //        if (long.TryParse(Console.ReadLine(), out placeCapacity) == false)
            //        {
            //            Console.WriteLine("Error! Retry!");
            //        }
            //        else
            //        {
            //            isCorrect = true;
            //        }
            //    }

            //    var buildYear = 0;
            //    isCorrect = false;
            //    while (isCorrect == false)
            //    {
            //        Console.Write("Cinema build year: ");
            //        if (int.TryParse(Console.ReadLine(), out buildYear) == false || buildYear > 2021 || buildYear < 1890)
            //        {
            //            Console.WriteLine("Error! Retry!");
            //        }
            //        else
            //        {
            //            isCorrect = true;
            //        }
            //    }

            //    cinemaController1.AddCinema(new Cinema(name, (CinemaRank)rankInt, placeCapacity, buildYear));

            //    Console.Write("Add another one? [y/n] : ");
            //    input = Console.ReadLine();
            //}
            {
                cinemaController1.AddCinema(new Cinema("FirstCinema", CinemaRank.VideoFilm, 150, 1990));
                cinemaController1.AddCinema(new Cinema("Maneskin", CinemaRank.WideScreenFilm, 200, 1866));
                cinemaController1.AddCinema(new Cinema("Maneskin", CinemaRank.WideScreenFilm, 200, 1866));
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
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("cinemas.xml", settings))
            {
                writer.WriteStartElement("cinemas");
                foreach (var cinema in cinemaController1.Cinemas)
                {
                    writer.WriteStartElement("cinema");
                    writer.WriteElementString("name", cinema.Name);
                    writer.WriteElementString("rank", cinema.Rank.ToString());
                    writer.WriteElementString("placeCapacity", cinema.PlaceCapacity.ToString());
                    writer.WriteElementString("buildYear", cinema.BuildYear.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            XDocument xmlDoc = XDocument.Load("cinemas.xml");

            // Ordering by year. 
            Console.WriteLine("1. Order by year");
            var task1 = xmlDoc.Descendants("cinema")
                .OrderBy(cinema => (long)cinema.Element("buildYear"));
            PrintSequnce(task1);

            // Sorting long form.
            var minYear = 2000;
            var minCapacity = 100;
            Console.WriteLine($"2. Sorting long form, build year >= {minYear} minCapacity => {minCapacity}");
            var task2 = from x in xmlDoc.Root.Elements("cinema")
                        where (int)x.Element("buildYear") >= minYear && (long)x.Element("placeCapacity") >= minCapacity
                        select x;
            PrintSequnce(task2);

            // Sorting short form.
            var startLetter = 'A';
            Console.WriteLine($"3. Sorting short form, starts with {startLetter}");
            var task3 = cinemaController1.Cinemas
                .Where(x => x.Name[0] == startLetter);
            PrintSequnce(task3);

            // SkipWhile && TakeWhile
            minYear = 2002;
            var maxYear = 2008;
            Console.WriteLine($"4. Get cinemas, built from {minYear} to {maxYear}");
            var task4 = task1.SkipWhile(x => (int)x.Element("buildYear") < minYear)
                .TakeWhile(x => (int)x.Element("buildYear") <= maxYear);
            PrintSequnce(task4);

            // Get names and sort in reversed alphabetical order
            Console.WriteLine("5. Get names in reversed alphabetical order");
            var task5 = xmlDoc.Descendants("cinema")
                .Select(cinema => cinema.Element("name").Value)
                .OrderByDescending(name => name[0]);
            PrintSequnce(task5);

            // Groupping
            Console.WriteLine("6. Get count of each cinema rank");
            var task6 = xmlDoc.Descendants("cinema")
                .GroupBy(cinema => cinema.Element("rank").Value)
                .Select(g => new { Key = g.Key, Count = g.Count() });
            PrintSequnce(task6);

            // Max
            Console.WriteLine("7. Get cinema with max build year");
            var maxValue = xmlDoc.Descendants("cinema").Max(xe => xe.Element("buildYear").Value);
            var task7 = xmlDoc.Descendants("cinema").First(ex => ex.Element("buildYear").Value == maxValue);
            Console.WriteLine($"{task7}\n");

            // Average
            Console.WriteLine("8. Average place capacity");
            var task8 = xmlDoc.Descendants("cinema")
                .Average(el => long.Parse(el.Element("placeCapacity").Value));
            Console.WriteLine($"{task8}\n");

            // Distinct
            Console.WriteLine("9. First or default"); 
            var task9 = xmlDoc.Descendants("cinema")
                .FirstOrDefault(x => long.Parse(x.Element("placeCapacity").Value) == 3); 
            Console.WriteLine(task9 == null ? "null" : task9.ToString());
            Console.WriteLine();

            // Converte to cimena class instances
            Console.WriteLine($"10. Converte to cimena class instances");
            var task10 = from xe in xmlDoc.Root.Elements("cinema")
                         select new Cinema
                         (
                             xe.Element("name").Value,
                             (CinemaRank)Enum.Parse(typeof(CinemaRank), xe.Element("rank").Value.ToString()),
                             long.Parse(xe.Element("placeCapacity").Value),
                             int.Parse(xe.Element("buildYear").Value)
                         );
            PrintSequnce(task10);
        }

        private static void PrintSequnce(IEnumerable enumarable)
        {
            foreach (var x in enumarable)
            {
                Console.Write("\t");
                if (x is XElement xElement)
                {
                    Console.WriteLine($"Name: {xElement.Element("name").Value}, " +
                        $"Rank: {xElement.Element("rank").Value}, " +
                        $"Capacity: {xElement.Element("placeCapacity").Value}, " +
                        $"Build year: {xElement.Element("buildYear").Value}");
                }
                else
                {
                    Console.WriteLine(x);
                }
            }
            Console.WriteLine();
        }
    }
}
