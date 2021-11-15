using System;
using TaskMediapark.API.Controllers;
using TaskMediapark.Service.Abstract;
using Xunit;
using Moq;
using TaskMediapark.Service.Concrete;
using TaskMediapark.Domain.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit.Extensions;
using TaskMediapark.API.JSONParsers;
using TaskMediapark.API.Utilities;

namespace UnitTests
{
    public class HolidayControllerTest
    {
        private readonly Mock<IHolidayService> mock = new Mock<IHolidayService>();

        HolidayController holidayController;
        HolidayHandler holidayHandler;
        public HolidayControllerTest()
        {
            holidayController = new HolidayController(mock.Object);
        }

        [Fact]
        public void GetHolidays_TestHolildaysCount()
        {
            holidayHandler = new HolidayHandler(mock.Object);
            CountryYearParser parser = new CountryYearParser()
            {
                country = "est",
                year = 2022
            };

            var result = holidayHandler.GetHolidays(parser.country, parser.year);

            Assert.NotNull(result);

            Assert.Equal(16, result.Result.Count);

            Assert.IsType<List<HolidayDto>>(result.Result);
        }
    }
}
