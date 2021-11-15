using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;
using TaskMediapark.Domain.Mapping;
using TaskMediapark.Domain.Repositories;
using TaskMediapark.Persistence.SQL.Abstract;

namespace TaskMediapark.Persistence.SQL
{
    public class SQLCountryRepository : SQLGenericRepository<Country>, ICountryRepository
    {

        public SQLCountryRepository(MediaparkDbContext dbContext) : base(dbContext)
        {

        }
        public List<Country> GetCountries()
        {
            List<Country> countryList = dbContext.Countries.ToList();
            return countryList;
        }
    }
}
