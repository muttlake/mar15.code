

using System;
using System.Collections.Generic;
using ContactApp.Library.Interfaces;
using ContactApp.Library.Models;

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






    }
}