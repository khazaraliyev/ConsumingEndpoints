using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMediapark.Domain.DTOs
{
    public class DayDto
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string country { get; set; }
        public string status { get; set; }
    }
}
