﻿namespace lab1
{
    class Book : ISoldable
    {
        public string Title { get; }

        public double Price { get; }

        public Book(string title, double price)
        {
            Title = title;
            Price = price;
        }
    }
}
