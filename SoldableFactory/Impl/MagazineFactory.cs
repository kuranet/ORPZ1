namespace lab1
{
    class MagazineFactory : SoldableFactory
    {
        public ISoldable Create(SoldableConfiguration configuration)
        {
            return new Magazine(configuration);
        }
    }
}
