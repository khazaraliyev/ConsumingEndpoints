using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TaskMediapark.API.Utilities;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Domain.Entities;
using TaskMediapark.Service.Abstract;

namespace TaskMediapark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;
        RequestSender requestSender;
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        [Route("countries")]
        public async Task<List<CountryDto>> GetCountries()
        {
            List<CountryDto> countries = countryService.GetCountries();
            if (countries.Count != 0 && countries != null)
            {
                return countries;
            }
            else
            {
                requestSender = new RequestSender();

                string countriesEndpoint = "https://kayaposoft.com/enrico/json/v2.0/?action=getSupportedCountries";

                List<CountryDto> country = JsonSerializer.Deserialize<List<CountryDto>>(await requestSender.SendRequest(countriesEndpoint));

                foreach (var item in country)
                {
                    countryService.Create(item);
                }
                return country;

            }
        }
    }
}
