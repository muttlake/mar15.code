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
            PlayWithEvents();
        }

        static void PlayWithEvents()
        {
            var b = new Broadcaster();
            var r = new Receiver();

            r.Receive(b);
            b.Broadcast();
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
        }
    }
}
