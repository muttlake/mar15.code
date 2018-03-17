

using System;

namespace ContactApp.Client
{
    public class Receiver2
    {
        public void Receiving(Broadcaster2 b2)
        {
            b2.EventFire += (() => Console.WriteLine("Broadcast received"));
            b2.EventFire += WhatsUp;

            b2.EventHappened += WhatHappened;

        }

        private void WhatsUp()
        {
            Console.WriteLine("Whats UP");
        }

        private string WhatHappened(int i)
        {
            return i.ToString() + " WhatHappened";
        }
    }
}