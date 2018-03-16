

using System;
using System.Collections.Generic;
using ContactApp.Library.Interfaces;
using ContactApp.Library.Models;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace ContactApp.Library
{
    public class ContactHelper<T> : IContact
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




    }
}