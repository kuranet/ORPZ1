using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    public class SoldableProvider : ISoldableProvider
    {
        private static SoldableProvider _instance = new SoldableProvider();
        public static SoldableProvider GetInstance() => _instance;

        private List<ISoldableHolder> _holders = new List<ISoldableHolder>();

        public void RegisterHolder(ISoldableHolder soldableHolder)
        {
            if (_holders.Any(holder => holder == soldableHolder))
            {
                Console.WriteLine("Error: Attemp to rereqister soldable holder");
                return;
            }

            _holders.Add(soldableHolder);
        }

        public bool TryGetHolders(string soldableTitle, out IEnumerable<ISoldableHolder> foundHolders)
        {
            var suitableHolders = new List<ISoldableHolder>();

            foreach (var holder in _holders)
            {
                foreach (var soldable in holder.Soldables)
                {
                    if (soldable.Title != soldableTitle)
                    {
                        continue;
                    }

                    // Some holder can contains more that one copy of the book.
                    if (suitableHolders.Contains(holder))
                    {
                        continue;
                    }

                    suitableHolders.Add(holder);
                }
            }

            foundHolders = suitableHolders;

            return foundHolders.Any();
        }
    }
}
