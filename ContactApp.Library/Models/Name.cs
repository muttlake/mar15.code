

namespace ContactApp.Library.Models
{
    public class Name 
    {
        public string First { get; set; }   
        public string Last { get; set; }

        public Name()
        {
            First = "Simon";
            Last = "Gosselar";
        }

        public Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        public override string ToString()
        {
            return $"{First} {Last}";
        }
    }
}