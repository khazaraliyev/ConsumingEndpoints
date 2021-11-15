using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMediapark.API.JSONParsers
{
    public class GetHolidaysObject
    {
        public Periods date { get; set; }
        public string holidayType { get; set; }
        public List<Langs> name { get; set; }

        public GetHolidaysObject()
        {
            name = new List<Langs>();
        }
    }

    public class Periods
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int dayOfWeek { get; set; }
    }

    public class Langs
    {
        public string lang { get; set; }
        public string text { get; set; }
    }
}
