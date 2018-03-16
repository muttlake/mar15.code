

namespace ContactApp.Library.Models
{
    public class Phone
    {
        public string AreaCode { get; set; }
        public string Number { get; set; } 

        public Phone()
        {
            AreaCode = "000";
            Number = "000-0000";
        }

        public Phone(string area, string number)
        {
            AreaCode = area;
            Number = number;
        }

        public override string ToString()
        {
            return $"{AreaCode} {Number}";
        }
    }
}