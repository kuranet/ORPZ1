using System.Collections.Generic;

namespace lr3
{
    // Observer
    class PostOffice
    {
        private readonly List<IReceiver> _receivers = new List<IReceiver>();

        public void AddReceiver(IReceiver receiver)
        {
            _receivers.Add(receiver);
        }

        public void RemoveReceiver(IReceiver receiver)
        {
            _receivers.Remove(receiver);
        }

        public bool TryReceiveNewPress(IPress press)
        {
            foreach (var receiver in _receivers)
            {
                if (receiver.TryReceivePress(press) == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
