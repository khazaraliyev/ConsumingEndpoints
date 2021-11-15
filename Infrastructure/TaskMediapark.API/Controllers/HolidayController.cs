using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TaskMediapark.API.JSONParsers;
using TaskMediapark.API.Utilities;
using TaskMediapark.API.ViewModels;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Service.Abstract;
using TaskMediapark.Service.Concrete;

namespace TaskMediapark.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidayController : ControllerBase
    {

        private readonly IHolidayService holidayService;
        HolidayGrouper grouper;
        HolidayHandler holidayHandler;

        public HolidayController(IHolidayService holidayService)
        {
            this.holidayService = holidayService;
        }

        [HttpPost]
        [Route("holidays")]
        public async Task<List<HolidaysListGroupedByMonth>> GetHolidaysByMonth([FromBody] CountryYearParser requestBody)
        {
            grouper = new HolidayGrouper();
            holidayHandler = new HolidayHandler(holidayService);

            List<HolidayDto> holidays = holidayService.GetHolidaysByMonthAndYear(requestBody.country, requestBody.year);
            if (holidays.Count != 0 && holidays != null)
            {
                return grouper.GroupHolidays(holidays);
            }
            else
            {
                return grouper.GroupHolidays(await holidayHandler.GetHolidays(requestBody.country,requestBody.year));
            }
        }


        [HttpPost]
        [Route("freedays")]
        public async Task<int> GetHolidaysInARow([FromBody] CountryYearParser requestBody)
        {
            List<HolidayDto> holidays = holidayService.GetHolidaysByMonthAndYear(requestBody.country, requestBody.year);
            if (holidays.Count == 0 || holidays == null)
            {
                holidayHandler = new HolidayHandler(holidayService);
                holidays = await holidayHandler.GetHolidays(requestBody.country, requestBody.year);
            }

            int maxSequence = 0;
            int currentSequence = 0;
            DateTime holidayDate = new DateTime(requestBody.year, holidays[0].month, holidays[0].day);
            for (int i = 1; i < holidays.Count; i++)
            {
                DateTime currentHolidayDate = new DateTime(requestBody.year, holidays[i].month, holidays[i].day);

                if (currentHolidayDate.Month == holidayDate.Month)
                {
                    TimeSpan gap = currentHolidayDate - holidayDate;

                    if (gap.Days == 1)
                    {
                        currentSequence++;
                        if (maxSequence < currentSequence)
                        {
                            maxSequence = currentSequence;
                        }
                    }
                    else
                    {
                        currentSequence = 0;
                    }
                }
                holidayDate = currentHolidayDate;
            }
            return maxSequence;
        }

    }
}
