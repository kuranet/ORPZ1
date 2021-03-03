namespace lab1
{
    class Program
    {
        private static SoldableProvider SoldableProvider { get; set; }

        static void Main(string[] args)
        {
            SoldableProvider = SoldableProvider.GetInstance();
            CreateShops();
        }

        private static void CreateShops()
        {
            var library1 = new Library();
            library1.AddSoldable(CreateBook("Mykhail Lutyi. The story of success", 2f));
            library1.AddSoldable(CreateMagazine("Shrek", 2f));
            SoldableProvider.RegisterHolder(library1);

            var library2 = new Library();
            library2.AddSoldable(CreateBook("KPI and future (horror/thriller)", .5f));
            library2.AddSoldable(CreateBook("C++ for young and stupid", 100f));
            library2.AddSoldable(CreateMagazine("\"I will be happy\" and other hilarious jokes you can tell yourself", 2f));
            library2.AddSoldable(CreateMagazine("My dict 2.0", 2f));
            library2.AddSoldable(CreateMagazine("Minecraft tutorial", 3f));
            SoldableProvider.RegisterHolder(library2);

            var newsdtand = new Newsstand();
            newsdtand.AddSoldable(CreateMagazine("Minecraft tutorial", 5f));
            newsdtand.AddSoldable(CreateMagazine("HOT MUSIC IN CAR 2021", 1f));
            SoldableProvider.RegisterHolder(newsdtand);
        }

        private static ISoldable CreateBook(string title, double price)
        {
            return new Book(title, price);
        }

        private static ISoldable CreateMagazine(string title, double price)
        {
            return new Magazine(title, price);
        }
    }
}
