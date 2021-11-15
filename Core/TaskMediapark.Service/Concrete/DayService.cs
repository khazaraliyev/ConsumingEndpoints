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
    public class DayService : IDayService
    {
        private readonly IDayRepository dayRepository;

        DayMapper mapper;
        public DayService(IDayRepository dayRepository)
        {
            this.dayRepository = dayRepository;
            mapper = new DayMapper();
        }

        public DayDto Create(DayDto dayDto)
        {
            dayRepository.Create(mapper.MapDtoToDay(dayDto, new Day()));
            return dayDto;
        }

        public DayDto GetDayStatus(DayDto dayDto)
        {
            var day = dayRepository.GetDayStatus(mapper.MapDtoToDay(dayDto, new Day()));
            if (day == null)
            {
                return null;
            }

            else
            {
                mapper.MapDayToDto(day, dayDto);
                return dayDto;
            }
        }
    }
}
