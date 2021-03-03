using System;

namespace lab1
{
    public class SoldableFactory
    {
        private BookFactory BookFactory { get; }
        private MagazineFactory MagazineFactory { get; }

        public SoldableFactory()
        {
            BookFactory = new BookFactory();
            MagazineFactory = new MagazineFactory();
        }

        ISoldable Create(SoldableConfiguration configuration)
        {
            switch (configuration.Type)
            {
                case SoldableType.Book:
                    {
                        return BookFactory.Create(configuration);
                    }

                case SoldableType.Managine:
                    {
                        return MagazineFactory.Create(configuration);
                    }

                default:
                    {
                        throw new ArgumentException("SoldableFactory: Unexpected soldable type.");
                    }
            }
        }
    }
}
