namespace lab1
{
    public class Book : ISoldable
    {
        public string Title => Configuration.Title;

        public double Price => Configuration.Price;

        private SoldableConfiguration Configuration { get; }

        public Book(SoldableConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
