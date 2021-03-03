using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    public class Newsstand : ISoldableHolder
    {
        private List<ISoldable> _soldables = new List<ISoldable>();

        public string HoldersName { get; }

        public IEnumerable<ISoldable> Soldables => _soldables;

        public void AddSoldable(ISoldable soldable)
        {
            _soldables.Add(soldable);
        }

        public bool TryRemoveSoldable(ISoldable soldable)
        {
            if(Soldables.Any(s => s == soldable) == false)
            {
                Console.WriteLine("Error: Attemp to buy soldable, that doesn't belong to soldable holder.");
                return false;
            }

            _soldables.Remove(soldable);

            return true;
        }
    }
}
