using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Domain.Mapping
{
    public class CountryMapper
    {
        public CountryDto MapCountryToDto(CountryDto countryDto, Country country)
        {
            countryDto.fullName = country.Name;
            countryDto.countryCode = country.CountryCode;
            return countryDto;
        }

        public Country MapDtoToCountry(CountryDto countryDto, Country country)
        {
            country.Name = countryDto.fullName;
            country.CountryCode = countryDto.countryCode;
            return country;
        }
    }
}
