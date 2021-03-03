namespace lab1
{
    public class SoldableConfiguration
    {
        public SoldableType Type { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
    }

    public enum SoldableType
    {
        Book,
        Managine,
    }
}
