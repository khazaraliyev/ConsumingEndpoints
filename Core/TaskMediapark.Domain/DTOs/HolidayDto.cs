using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMediapark.Domain.DTOs
{
    public class HolidayDto
    {
        public string name { get; set; }
        public string country { get; set; }
        public int day { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public string holidayType { get; set; }

    }
}
