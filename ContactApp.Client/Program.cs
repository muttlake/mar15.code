using System;
using ContactApp.Library;
using ContactApp.Library.Models;

namespace ContactApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithContacts();
        }
        static void PlayWithContacts()
        {
            var ch = new ContactHelper<Person>();
            ch.Add(new Person());
            ch.Add(new Person("Crocker", "Davis"));
            ch.Add(new Person("Horace", "Slughorn"));

            var alfred = new Person("Alfred", "the Great", "777", "345-3455");
            ch.Add(alfred);

            foreach (var item in ch.Read())
            {
                Console.WriteLine(item);
            }
        }
    }
}
