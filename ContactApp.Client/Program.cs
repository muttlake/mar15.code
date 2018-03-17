using System;
using ContactApp.Library;
using ContactApp.Library.Models;

namespace ContactApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //PlayWithContacts();
            //PlayWithEvents();
            PlayWithEvents2();
        }

        static void PlayWithEvents()
        {
            var b = new Broadcaster();
            var r = new Receiver();

            b.Broadcast();
            r.Receive(b);
            b.Broadcast();
        }

        static void PlayWithEvents2()
        {
            var b = new Broadcaster2();
            var r = new Receiver2();
            var r2 = new Receiver2();

            r.Receiving(b);
            r2.Receiving(b);

            b.BroadCast();
        }
        static void PlayWithContacts()
        {
            var ch = new ContactHelper<Person>();
            ch.Add(new Person("Betty", "White"));
            ch.Add(new Person("Crocker", "Davis"));
            ch.Add(new Person("Horace", "Slughorn"));

            var alfred = new Person("Alfred", "the Great", "777", "345-3455");
            ch.Add(alfred);

            foreach (var item in ch.Read())
            {
                Console.WriteLine(item);
            }
            // ch.WriteToText();
            ch.WriteToXml();
            Person p = ch.ReadFromXml() as Person;
            ch.Add(p);
            ch.WriteToText();
            ch.Clear();

            Console.WriteLine("\n\n");
            ch.PlayWithDelegates();
        }
    }
}
