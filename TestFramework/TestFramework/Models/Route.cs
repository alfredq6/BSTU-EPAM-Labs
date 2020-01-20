
namespace TestFramework.Models
{
    public class Route
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureDate { get; set; }

        public Route(string departureCity, string arrivalCity, string departureDate)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DepartureDate = departureDate;
        }
    }
}
