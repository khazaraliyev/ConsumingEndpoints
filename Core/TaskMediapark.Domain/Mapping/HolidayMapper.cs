using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Domain.Mapping
{
    public class HolidayMapper
    {
        public HolidayDto MapHolidayToDto(HolidayDto holidayDto, Holiday holiday)
        {
            holidayDto.name = holiday.Name;
            holidayDto.country = holiday.Country;
            holidayDto.day = holiday.Date.Day;
            holidayDto.month = holiday.Date.Month;
            holidayDto.year = holiday.Date.Year;
            holidayDto.holidayType = holiday.HolidayType;
            return holidayDto;
        }

        public Holiday MapDtoToHoliday(HolidayDto holidayDto, Holiday holiday)
        {
            holiday.Name = holidayDto.name;
            holiday.Country = holidayDto.country;
            holiday.Date = new DateTime(holidayDto.year, holidayDto.month, holidayDto.day);
            holiday.HolidayType = holidayDto.holidayType;
            return holiday;
        }
    }
}
