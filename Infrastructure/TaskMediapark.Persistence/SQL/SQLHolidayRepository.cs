using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;
using TaskMediapark.Domain.Repositories;
using TaskMediapark.Persistence.SQL.Abstract;

namespace TaskMediapark.Persistence.SQL
{
    public class SQLHolidayRepository : SQLGenericRepository<Holiday>, IHolidayRepository
    {
        public SQLHolidayRepository(MediaparkDbContext dbContext) : base(dbContext)
        {

        }
        public List<Holiday> GetHolidays(string country, int year)
        {

            List<Holiday> holidays = dbContext.Holidays.Where(h =>
                                                               h.Date.Year == year &&
                                                               h.Country == country).OrderBy(h => h.Date).ToList();
            return holidays;

        }
    }
}
