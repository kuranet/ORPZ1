namespace lr3
{
    class Magazine : IPress
    {
        public string Title { get; }
        public PressType PressType => PressType.Magazine;

        public Magazine(string title)
        {
            Title = title;
        }
    }
}
