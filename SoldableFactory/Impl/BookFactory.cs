namespace lab1
{
    public class BookFactory : SoldableFactory
    {
        public ISoldable Create(SoldableConfiguration configuration)
        {
            return new Book(configuration);
        }
    }
}
