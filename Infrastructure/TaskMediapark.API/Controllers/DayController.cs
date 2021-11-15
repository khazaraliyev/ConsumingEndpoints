using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TaskMediapark.API.JSONParsers;
using TaskMediapark.API.Utilities;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Service.Abstract;

namespace TaskMediapark.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayController : ControllerBase
    {
        private readonly IDayService dayService;
        RequestSender requestSender;
        public DayController(IDayService dayService)
        {
            this.dayService = dayService;
        }

        [HttpPost]
        [Route("daystatus")]
        public async Task<DayDto> GetDayStatus([FromBody] DayMonthYearParser requestBody)
        {
            DayDto dayDto = new DayDto()
            {
                day = requestBody.day,
                month = requestBody.month,
                year = requestBody.year,
                country = requestBody.country
            };

            DayDto specificDay = dayService.GetDayStatus(dayDto);

            if (specificDay != null)
            {
                return specificDay;
            }

            requestSender = new RequestSender();

            string date = $"{requestBody.day}-{requestBody.month}-{requestBody.year}";

            string getHolidayType = $"https://kayaposoft.com/enrico/json/v2.0/?action=getHolidaysForDateRange&fromDate={date}&toDate={date}&country={requestBody.country}";

            string response = await requestSender.SendRequest(getHolidayType);

            if (response != "[]" && !String.IsNullOrWhiteSpace(response))
            {
                List<DayObject> day = JsonSerializer.Deserialize<List<DayObject>>(response);
                foreach (var item in day)
                {
                    dayDto.status = item.holidayType;
                    dayService.Create(dayDto);
                    return dayDto;
                }
            }

            else
            {
                string isWorkDayEndpoint = $"https://kayaposoft.com/enrico/json/v2.0/?action=isWorkDay&date={date}&country={requestBody.country}";
                DayObject workDay = JsonSerializer.Deserialize<DayObject>(await requestSender.SendRequest(isWorkDayEndpoint));
                if (workDay.isWorkDay)
                {
                    dayDto.status = "workDay";
                    dayService.Create(dayDto);
                    return dayDto;
                }
                dayDto.status = "freeDay";
            }
            dayService.Create(dayDto);
            return dayDto;
        }
    }
}

