

using System.Collections.Generic;
using ContactApp.Library.Enums;
using System.Xml.Serialization;
using ContactApp.Library.Interfaces;
using System;

namespace ContactApp.Library.Models
{
    public class Person: IContact
    {

        public long PId { get; set; }
        public Name Name { get; set; }
        public Phone Phone { get; set; }
        
        [XmlIgnore]
        public Dictionary<ContactEnum, string> Email { get; set; }

        [XmlIgnore]
        public Dictionary<ContactEnum, Address> Address { get; set; }

        public Person()
        {
            Name = new Name();
            Init();
        }

        public Person(string first, string last)
        {
            Name = new Name(first, last);
            Init();
        }

        public Person(string first, string last, string area, string number)
        {
            PId = DateTime.Now.Ticks;
            Name = new Name(first, last);
            Phone = new Phone(area, number);
            Email = new Dictionary<ContactEnum, string>();
            Address = new Dictionary<ContactEnum, Address>();
        }

        private void Init()
        {
            PId = DateTime.Now.Ticks;
            Phone = new Phone();
            Email = new Dictionary<ContactEnum, string>();
            Address = new Dictionary<ContactEnum, Address>();
        }

        public override string ToString()
        {
            string outString = "\n";
            outString += string.Format("{0}", Name);
            outString += string.Format("\n{0}", Phone);
            outString += string.Format("\n{0}", Email);
            outString += string.Format("\n{0}", Address);
            return outString;
        }
    }
}