using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TaskMediapark.API.Controllers;
using TaskMediapark.Service.Abstract;
using Xunit;

namespace UnitTests
{
    public class CountryControllerTest
    {
        private readonly Mock<ICountryService> mock = new Mock<ICountryService>();

        CountryController countryController;
        public CountryControllerTest()
        {
            countryController = new CountryController(mock.Object);
        }

        [Fact]
        public void GetCountries_TestListOfCountries()
        {

            var result = countryController.GetCountries();

            Assert.NotNull(result);
        }
    }
}
