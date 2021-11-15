using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMediapark.API.ViewModels;
using TaskMediapark.Domain.DTOs;

namespace TaskMediapark.API.Utilities
{
    public class HolidayGrouper
    {

        HolidaysListGroupedByMonth month;
        List<HolidaysListGroupedByMonth> byMonth;
        public List<HolidaysListGroupedByMonth> GroupHolidays(List<HolidayDto> holidays)
        {
            IEnumerable<int> list = holidays.Select(x => x.month).Distinct();

            var distinct = holidays.GroupBy(x => x.month).Select(c => c.First()).ToList();
            byMonth = new List<HolidaysListGroupedByMonth>();

            foreach (var item in distinct)
            {
                month = new HolidaysListGroupedByMonth()
                {
                    Month = item.month,
                };

                foreach (var hol in holidays)
                {
                    if (hol.month == item.month)
                    {
                        month.HolidayList.Add(hol);
                    }
                }
                byMonth.Add(month);
            }
            return byMonth;
        }
    }
}
