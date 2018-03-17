

using System;

namespace ContactApp.Client
{
    public class Broadcaster2
    {
        public delegate void Notifier();

        public event Notifier EventFire;

        public delegate string Notifieder(int i);
        
        public event Notifieder EventHappened;

        public void BroadCast()
        {
            for(int i = 0; i < 10; i+=1)
            {
                EventFire();
                string s = EventHappened(i);
                System.Console.WriteLine(s);
            }
        }
    }
}