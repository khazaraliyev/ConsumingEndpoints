using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TaskMediapark.API.JSONParsers;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Service.Abstract;

namespace TaskMediapark.API.Utilities
{
    public class HolidayHandler
    {
        private readonly IHolidayService holidayService;

        public HolidayHandler(IHolidayService holidayService)
        {
            this.holidayService = holidayService;
        }

        RequestSender requestSender = new RequestSender();
        public async Task<List<HolidayDto>> GetHolidays(string country, int year)
        {
            List<HolidayDto> holidays = new List<HolidayDto>();
            requestSender = new RequestSender();
            HolidayDto holiday;
            string holidaysEndpoint = $"https://kayaposoft.com/enrico/json/v2.0/?action=getHolidaysForYear&year={year}&country={country}";
            List<GetHolidaysObject> holidayParser = JsonSerializer.Deserialize<List<GetHolidaysObject>>(await requestSender.SendRequest(holidaysEndpoint));

            foreach (var item in holidayParser)
            {
                holiday = new HolidayDto
                {
                    day = item.date.day,
                    month = item.date.month,
                    year = item.date.year,
                    name = item.name.First(i => i.lang == "en").text,
                    holidayType = item.holidayType,
                    country = country
                };
                holidays.Add(holiday);
                holidayService.Create(holiday);
            }
            return holidays;
        }
    }
}
