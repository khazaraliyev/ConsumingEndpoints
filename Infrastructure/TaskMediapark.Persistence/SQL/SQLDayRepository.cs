using Microsoft.EntityFrameworkCore;
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
    public class SQLDayRepository : SQLGenericRepository<Day>, IDayRepository
    {
        public SQLDayRepository(MediaparkDbContext dbContext) : base(dbContext)
        {

        }
        public Day GetDayStatus(Day day)
        {
            var specificDay = dbContext.Days.Where(d => d.Country == day.Country &&
                           d.Date.Year == day.Date.Year &&
                           d.Date.Month == day.Date.Month &&
                           d.Date.Day == day.Date.Day
                           ).FirstOrDefault();
            return specificDay;
        }
    }
}

