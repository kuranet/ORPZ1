using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    class Library : ISoldableHolder
    {
        private List<SoldableWrapper> _soldables = new List<SoldableWrapper>();

        public string HoldersName { get; }

        public IEnumerable<ISoldable> Soldables => 
            _soldables
            .Where(soldable => soldable.IsAwaliable == true)
            .Select(wrapped => wrapped.Soldable);

        public void AddSoldable(ISoldable soldable)
        {
            _soldables.Add(new SoldableWrapper(soldable));
        }

        public bool TryRemoveSoldable(ISoldable soldable)
        {
            var soldableWrapper = _soldables.FirstOrDefault(s => s == soldable && s.IsAwaliable == true);

            if (soldableWrapper == null)
            {
                Console.WriteLine("Error: Attemp to buy soldable, that doesn't belong to soldable holder or not available now.");
                return false;
            }

            _soldables.Remove(soldableWrapper);

            return true;
        }

        public void GetInRent(ISoldable soldable) => _soldables.First(s => s == soldable).GetInRent();
        public void ReturnFromRent(ISoldable soldable) => _soldables.First(s => s == soldable).ReturnFromRent();

        private class SoldableWrapper
        {
            private bool _isInRend;

            public ISoldable Soldable { get; }
            public bool IsAwaliable => _isInRend == false;

            public SoldableWrapper(ISoldable soldable)
            {
                Soldable = soldable;
            }

            public void GetInRent() => _isInRend = true;
            public void ReturnFromRent() => _isInRend = false;
        }
    }
}
