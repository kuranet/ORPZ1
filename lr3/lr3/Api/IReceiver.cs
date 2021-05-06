using System.Collections.Generic;

namespace lr3
{
    interface IReceiver
    {
        List<(string, int)> SubcribtedTitles { get; }

        void AddSubscribation(string title);
        void RemoveSubsribation(string title);

        bool TryReceivePress(IPress press);
    }
}
