namespace lr3
{
    class Newspaper : IPress
    {
        public string Title { get; }
        public PressType PressType => PressType.Newspaper;

        public Newspaper(string title)
        {
            Title = title;
        }
    }
}
