using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Service.Abstract
{
    public interface IDayService
    {
        public DayDto Create(DayDto dayDto);
        public DayDto GetDayStatus(DayDto dayDto);
    }
}
