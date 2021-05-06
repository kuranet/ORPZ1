using System;

namespace lr3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set system.
            var publisher = new Publisher();

            var postOffice1 = new PostOffice();
            var receiver1_1 = CresteReceiver("Tom");
            receiver1_1.AddSubscribation("Jojo");
            var receiver1_2 = CresteReceiver("Bob");
            receiver1_2.AddSubscribation("KPI chronicle");
            receiver1_2.AddSubscribation("Dory");
            postOffice1.AddReceiver(receiver1_1);
            postOffice1.AddReceiver(receiver1_2);
            publisher.AddPostOffice(postOffice1);

            var postOffice2 = new PostOffice();
            var receiver2_1 = CresteReceiver("Midy");
            receiver2_1.AddSubscribation("Miami weekend");
            var receiver2_2 = CresteReceiver("Lola");
            receiver2_2.AddSubscribation("Jojo");
            receiver2_2.AddSubscribation("The Gardener");
            var receiver2_3 = CresteReceiver("Katty");
            receiver2_3.AddSubscribation("Kyiv herald");
            postOffice2.AddReceiver(receiver2_1);
            postOffice2.AddReceiver(receiver2_2);
            postOffice2.AddReceiver(receiver2_3);
            publisher.AddPostOffice(postOffice2);

            // Act.
            publisher.GenerateDistribution();
        }

        static Receiver CresteReceiver(string name)
        {
            var receiver = new Receiver(name);
            receiver.PressReceiver += ReceiveEvent;
            return receiver;
        }

        static void ReceiveEvent(Receiver receiver, IPress press)
        {
            Console.WriteLine($"{receiver.Name} received \"{press.Title}\" {press.PressType}");
        }
    }
}
