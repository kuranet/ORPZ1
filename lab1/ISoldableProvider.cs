﻿using System.Collections.Generic;

namespace lab1
{
    interface ISoldableProvider
    {
        void RegisterHolder(ISoldableHolder soldableHolder);
        bool TryGetHolders(string soldableTitle, out IEnumerable<ISoldableHolder> foundHolders);
    }
}
