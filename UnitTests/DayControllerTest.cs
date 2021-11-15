using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using TaskMediapark.API.Controllers;
using TaskMediapark.API.JSONParsers;
using TaskMediapark.Domain.DTOs;
using TaskMediapark.Service.Abstract;
using Xunit;

namespace UnitTests
{
    public class DayControllerTest
    {
        private readonly Mock<IDayService> mock = new Mock<IDayService>();

        DayController dayController;
        public DayControllerTest()
        {
            dayController = new DayController(mock.Object);
        }

        [Fact]
        public void GetDayStatus_TestStatusOfSpecificDay()
        {
            DayMonthYearParser day = new DayMonthYearParser()
            {
                day = 05,
                month = 07,
                year = 2022,
                country = "svk"
            };
            var result = dayController.GetDayStatus(day);

            Assert.NotNull(result);

            Assert.Equal("public_holiday", result.Result.status);
        }
    }
}
