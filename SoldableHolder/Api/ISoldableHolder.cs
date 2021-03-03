using System.Collections.Generic;

namespace lab1
{
    public interface ISoldableHolder
    {
        string HoldersName { get; }

        IEnumerable<ISoldable> Soldables { get; }

        bool TryRemoveSoldable(ISoldable soldable);
    }
}
