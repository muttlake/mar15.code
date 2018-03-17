

using System;
using System.Collections.Generic;
using ContactApp.Library.Interfaces;
using ContactApp.Library.Models;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace ContactApp.Library
{
    public class ContactHelper<T> where T : IContact, new()  // T must be of type IContact, and must have constructor
    {
        private static List<T> _container = new List<T>();

        public bool Add(T t)
        {
            try
            {
                _container.Add(t);
                return true;
                
            }
            catch (ArgumentNullException e)
            {
                _container.Add(t);
                return true;
                throw new Exception("Null Argument, but added item anyway.", e);
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Something went wrong.", e);
            }
            finally
            {
                GC.Collect();
            }
        }

        public int Size()
        {
            return _container.Count;
        }

        public List<T> Read()
        {
            return _container;
        }

        public void Clear()
        {
            _container.Clear();
        }

        public void WriteToText()
        {
            string path = @"C:\Revature\mar15Code.redo\mar15.code\contacts.txt";
            using(var outputFile = new StreamWriter(path))
            {
                foreach (var item in _container)
                {
                    outputFile.WriteLine(item);
                }
            }
        }

        public void WriteToXml()
        {
            string path = @"C:\Revature\mar15Code.redo\mar15.code\contacts.xml";

            using(var outStream = new StreamWriter(path))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(outStream, _container.FirstOrDefault());

                // foreach (var item in _container)
                // {
                //     xmlSerializer.Serialize(outStream, item);
                // }
            }

        }

        public T ReadFromXml()
        {
            string path = @"C:\Revature\mar15Code.redo\mar15.code\contacts.xml";
            T t;

            using (var inStream = new StreamReader(path))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                t = (T) xmlSerializer.Deserialize(inStream);
            }

            return t;
        }

        public void Update(T t)
        {
            var a = _container.First(p => p.PId == t.PId);
            var a2 = _container.First(p => true);
            var a3 = _container.First(p => p.PId < t.PId);
            var a4 = _container.Where(p => p.PId == t.PId).First();
            var a5 = _container.Where(p => false);
            int foundIndex = GetItemIndex(t);
            if(foundIndex == -999)
                Console.WriteLine("Item with PID not found.");
            else
            {
                _container[foundIndex] = t;
            }
            
        }

        private int GetItemIndex(T t)
        {
            int foundIndex = -999;
            for (int i = 0; i < _container.Count; i += 1)
            {
                if(_container[i].PId == t.PId)
                {
                    foundIndex = i;
                    break;
                }
            }
            return foundIndex;
        }


        public void PlayWithDelegates()
        {
            Action<int> myAction = new Action<int>(WriteHello);
            myAction(123);

            Func<int, int> myFunc = new Func<int, int>(GetDouble);
            Console.WriteLine(myFunc(123));

            Predicate<int> myPred = new Predicate<int>(GetNumberLessThan5);
            for(int i = 0; i < 10; i++)
                if (myPred(i))
                    Console.WriteLine("Number Less than 5");



        }


        private void WriteHello(int num)
        {
            Console.WriteLine("Hello");
        }

        private int GetDouble(int num)
        {
            return num*num;
        }

        private bool GetNumberLessThan5(int num)
        {
            return num < 5;
        }




    }
}