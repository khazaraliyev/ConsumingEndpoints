using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Domain.Repositories
{
    public interface IHolidayRepository : IRepository<Holiday>
    {
        public List<Holiday> GetHolidays(string country, int year);
    }
}
