

using System;
namespace ContactApp.Client

{
    public class Receiver
    {
        public void Receive(Broadcaster b)
        {
            b.EventFire += () => {Console.WriteLine("EventFire event happenned");};
            b.EventFire += Listening;
            b.Event2 += () => {Console.WriteLine("Watching Waiting, Anticipating.  Event2");};
        }

        private void Listening()
        {
            Console.WriteLine("I am Listening.");
        }
    }
}