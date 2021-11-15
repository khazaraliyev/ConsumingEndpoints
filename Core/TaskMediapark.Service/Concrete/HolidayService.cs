using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;
using TaskMediapark.Domain.Mapping;
using TaskMediapark.Domain.Repositories;
using TaskMediapark.Service.Abstract;

namespace TaskMediapark.Service.Concrete
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository holidayRepository;
        List<HolidayDto> holidays;
        HolidayMapper mapper;
        public HolidayService(IHolidayRepository holidayRepository)
        {
            this.holidayRepository = holidayRepository;
            mapper = new HolidayMapper();
        }

        public HolidayDto Create(HolidayDto holiday)
        {
            holidayRepository.Create(mapper.MapDtoToHoliday(holiday, new Holiday()));
            return holiday;
        }
        public List<HolidayDto> GetHolidaysByMonthAndYear(string country, int year)
        {
            List<Holiday> countryList = holidayRepository.GetHolidays(country, year);
            HolidayDto holidayDto;
            holidays = new List<HolidayDto>();
            foreach (var item in countryList)
            {
                holidayDto = new HolidayDto();
                mapper.MapHolidayToDto(holidayDto, item);
                holidays.Add(holidayDto);
            }
            return holidays;
        }
    }
}
