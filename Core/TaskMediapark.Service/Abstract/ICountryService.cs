using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Service.Abstract
{
    public interface ICountryService
    {
        public CountryDto Create(CountryDto country);
        public List<CountryDto> GetCountries();
    }
}
