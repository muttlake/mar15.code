using System;
using System.Text.RegularExpressions;
using System.Threading;
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
            //PlayWithEvents2();
            //PlayWithParameters();
            PlayWithThreads();
        }

        static void PlayWithThreads()
        {
            var p = new Parallel();
            //p.WorkWithThread();
            //p.WorkWithTask();

            //p.WorkWithAsync();   // Nothing is output

            // p.WorkWithAsync(); // start Async thread
            // Thread.Sleep(10);  // only some C print out
            // Thread.Sleep(1000);  // all the C print out

            // p.WorkWithAsync().GetAwaiter(); // Tells main Thread to Wait when you get here
                                            // Nothing is printed
            
            p.WorkWithAsync().GetAwaiter().GetResult(); // Waits until Async is done
                                                        // this is actually like running synchronously
                                                        // All of the C are printed






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

        static void PlayWithParameters()
        {
            var names = new string[] {"fred", "langsto3n", "frankston", "land3on"};


            foreach (var name in names)
            {
                string validName = "";
                if(NameCheck(name, validName))
                    Console.WriteLine("The valid name is: " + validName);
                else
                {
                    Console.WriteLine("The invalid name is: " + validName);
                }
            }

            // foreach (var name in names) // This does work
            // {
            //     string validName = "";
            //     if(NameCheck(name, out validName))
            //         Console.WriteLine("The valid name is: " + validName);
            //     else
            //     {
            //         Console.WriteLine("The invalid name is: " + validName);
            //     }
            // }

            foreach (var name in names)
            {
                string validName = "";
                if(NameCheck(name, ref validName))
                {
                    Console.WriteLine("The valid name is: " + validName);
                }
                else
                {
                    Console.WriteLine("The invalid name is: " + validName);
                }
            }

        }

        static bool NameCheck(string name, string validName)
        {
            if(Regex.IsMatch(name, "^[a-z]*$"))
            {
                validName = name + "YesValid";
                return true;
            }
            validName = "NotValid";
            return false;
        }

        // static bool NameCheck(string name, out string validName) // This does work
        // {
        //     if(Regex.IsMatch(name, "^[a-z]*$"))
        //     {
        //         validName = name + "YesValid";
        //         return true;
        //     }
        //     validName = "NotValid";
        //     return false;
        // }


        static bool NameCheck(string name, ref string validName)
        {
            if(Regex.IsMatch(name, "^[a-z]*$"))
            {
                validName = name + "CheckYesIsValid";
                return true;
            }
            else
            validName = name + "NoIsntValid";
            return false;
        }
    }
}
