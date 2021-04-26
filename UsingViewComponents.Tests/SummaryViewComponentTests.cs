using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System.Collections.Generic;
using UsingViewComponents.Components;
using UsingViewComponents.Models;
using Xunit;

namespace UsingViewComponents.Tests
{
    public class SummaryViewComponentTests
    {
        [Fact]
        public void TestSummary()
        {
            // Организация
            Mock<ICityRepository> mockRepository = new Mock<ICityRepository>();
            mockRepository.SetupGet(m => m.Cities).Returns(new List<City> {
                new City { Population = 100 },
                new City { Population = 20000 },
                new City { Population = 1000000 },
                new City { Population = 500000 }
            });
            CitySummary viewComponent = new CitySummary(mockRepository.Object);

            // Действие
            ViewViewComponentResult result = viewComponent.Invoke(false) as ViewViewComponentResult;

            // Утверждение
            Assert.IsType<CityViewModel>(result.ViewData.Model);
            Assert.Equal(4, ((CityViewModel)result.ViewData.Model).Cities);
            Assert.Equal(1520100, ((CityViewModel)result.ViewData.Model).Population);
        }
    }
}
