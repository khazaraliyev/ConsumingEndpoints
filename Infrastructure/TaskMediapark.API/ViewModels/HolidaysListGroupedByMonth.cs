using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMediapark.Domain.DTOs;

namespace TaskMediapark.API.ViewModels
{
    public class HolidaysListGroupedByMonth
    {
        public HolidaysListGroupedByMonth()
        {
            HolidayList = new List<HolidayDto>();
        }
        public int Month { get; set; }
        public List<HolidayDto> HolidayList
        {
            get; set;
        }
    }
}
