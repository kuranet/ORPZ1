namespace lab1
{
    public class Magazine : ISoldable
    {
        public string Title { get; }

        public double Price { get; }

        public Magazine(string title, double price)
        {
            Title = title;
            Price = price;
        }
    }
}
