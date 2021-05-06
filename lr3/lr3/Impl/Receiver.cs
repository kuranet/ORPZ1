using System;
using System.Collections.Generic;
using System.Linq;

namespace lr3
{
    class Receiver : IReceiver
    {
        private readonly List<(string, int)> _subcribtedTitles = new List<(string, int)>();
        private readonly List<IPress> _receiverPress = new List<IPress>();

        public string Name { get; }
        public List<(string, int)> SubcribtedTitles => _subcribtedTitles;

        public event Action<Receiver, IPress> PressReceiver;

        public Receiver(string name)
        {
            Name = name;
        }

        public void AddSubscribation(string title)
        {
            var subcribation = SubcribtedTitles.FirstOrDefault(pair => pair.Item1 == title);
            if (subcribation == default)
            {
                _subcribtedTitles.Add((title, 1));
                return;
            }

            _subcribtedTitles[_subcribtedTitles.IndexOf(subcribation)] = (title, ++subcribation.Item2);
        }

        public void RemoveSubsribation(string title)
        {
            var subcribation = SubcribtedTitles.FirstOrDefault(pair => pair.Item1 == title);
            if (subcribation.Item2 == 1)
            {
                _subcribtedTitles.Remove(subcribation);
                return;
            }
            
            _subcribtedTitles[_subcribtedTitles.IndexOf(subcribation)] = (title, --subcribation.Item2);
        }

        public bool TryReceivePress(IPress press)
        {
            var subcribation = SubcribtedTitles.FirstOrDefault(pair => pair.Item1 == press.Title);
            if (subcribation == default)
            {
                return false;
            }

            var receivedCount = _receiverPress.Count(pres => pres.Title == press.Title);
            if (receivedCount == subcribation.Item2)
            {
                return false;
            }

            _receiverPress.Add(press);
            PressReceiver?.Invoke(this, press);

            return true;
        }
    }
}
