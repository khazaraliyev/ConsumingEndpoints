using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Domain.Mapping
{
    public class DayMapper
    {
        public Day MapDtoToDay(DayDto dayDto, Day day)
        {
            day.Date = new DateTime(dayDto.year, dayDto.month, dayDto.day);
            day.Country = dayDto.country;
            day.Status = dayDto.status;
            return day;
        }

        public DayDto MapDayToDto(Day day, DayDto dayDto)
        {
            dayDto.day = day.Date.Day;
            dayDto.month = day.Date.Month;
            dayDto.year = day.Date.Year;
            dayDto.country = day.Country;
            dayDto.status = day.Status;

            return dayDto;
        }
    }
}
