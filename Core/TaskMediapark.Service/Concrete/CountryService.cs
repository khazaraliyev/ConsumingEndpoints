using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;
using TaskMediapark.Domain.Mapping;
using TaskMediapark.Domain.Repositories;
using TaskMediapark.Service.Abstract;

namespace TaskMediapark.Service.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        CountryMapper mapper;
        List<CountryDto> countries;

        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
            mapper = new CountryMapper();
        }

        public CountryDto Create(CountryDto country)
        { 
            countryRepository.Create(mapper.MapDtoToCountry(country, new Country()));
            return country;
        }

        public List<CountryDto> GetCountries()
        {
            List<Country> countryList = countryRepository.GetCountries();
            CountryDto countryDto;
            countries = new List<CountryDto>();
            foreach (var item in countryList)
            {
                countryDto = new CountryDto();
                mapper.MapCountryToDto(countryDto, item);
                countries.Add(countryDto);
            }
            return countries;
        }
    }
}
