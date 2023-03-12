using AirportDistance_WebAPI.Models;

namespace AirportDistance_WebAPI.Services.Abstract
{
    public interface IAirportDistanceService
    {
        Task<double> Calculate(AirportCodes airportCodes);
    }
}
