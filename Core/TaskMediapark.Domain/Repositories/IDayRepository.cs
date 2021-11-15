using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Domain.Repositories
{
    public interface IDayRepository : IRepository<Day>
    {
        public Day GetDayStatus(Day day);
    }
}
