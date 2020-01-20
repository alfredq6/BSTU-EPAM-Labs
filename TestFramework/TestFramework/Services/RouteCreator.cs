using TestFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.Services
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"), DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
        }

        public static Route WithSameCities()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("DepartureCity"), DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
        }

        public static Route WithoutDate()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"), string.Empty);
        }
    }
}
