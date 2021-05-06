using System.Collections.Generic;

namespace lr3
{
    class Publisher
    {
        private List<PostOffice> _postOffices = new List<PostOffice>();
        private List<IPress> _createdPress = new List<IPress>();

        public void AddPostOffice(PostOffice postOffice)
        {
            _postOffices.Add(postOffice);
        }

        public void RemovePostOffice(PostOffice postOffice)
        {
            _postOffices.Remove(postOffice);
        }

        public void GenerateDistribution()
        {
            _createdPress.Add(CreatePress("Jojo", PressType.Magazine));
            _createdPress.Add(CreatePress("Jojo", PressType.Magazine));
            _createdPress.Add(CreatePress("Jojo", PressType.Magazine));
            _createdPress.Add(CreatePress("KPI chronicle", PressType.Newspaper));
            _createdPress.Add(CreatePress("The Gardener", PressType.Magazine));
            _createdPress.Add(CreatePress("Miami weekend", PressType.Magazine));
            _createdPress.Add(CreatePress("Dory", PressType.Magazine));
            _createdPress.Add(CreatePress("Kyiv herald", PressType.Newspaper));

            foreach (var postOffice in _postOffices)
            {
                for (var i = _createdPress.Count - 1; i >= 0; i--)
                {
                    var press = _createdPress[i];
                    if (postOffice.TryReceiveNewPress(press) == true)
                    {
                        _createdPress.Remove(press);
                    }
                }
            }
        }

        private IPress CreatePress(string title, PressType pressType)
        {
            IPress createdPress = null;

            switch (pressType)
            {
                case PressType.Magazine:
                    {
                        createdPress = new Magazine(title);
                        break;
                    }
                case PressType.Newspaper:
                    {
                        createdPress = new Newspaper(title);
                        break;
                    }
            }

            return createdPress;
        }
    }
}
