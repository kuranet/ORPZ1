namespace lab1
{
    public class Magazine : ISoldable
    {
        public string Title => Configuration.Title;

        public double Price => Configuration.Price;

        private SoldableConfiguration Configuration { get; }

        public Magazine(SoldableConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
