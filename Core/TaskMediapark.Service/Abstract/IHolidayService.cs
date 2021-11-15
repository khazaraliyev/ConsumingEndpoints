using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Service.Abstract
{
    public interface IHolidayService
    {
        public HolidayDto Create(HolidayDto holiday);
        public List<HolidayDto> GetHolidaysByMonthAndYear(string country, int year);
        //public List<HolidayDto> GetHolidaaysByYear(string country, int year);
    }
}
