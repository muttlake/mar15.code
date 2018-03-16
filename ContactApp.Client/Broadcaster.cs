

namespace ContactApp.Client
{
    public class Broadcaster
    {
        public delegate void Notifier();
        public event Notifier EventFire;

        public event Notifier Event2;

        public void Broadcast()
        {
            for(int i = 0; i < 10;  i+=1)
            {
                if (EventFire != null)
                    EventFire();
                if (Event2 != null)
                    Event2();
            }
        }
    }
}