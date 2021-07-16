using ProductionServiceSystem.Models;
using ProductionServiceSystem.ModelsDTO;
using ProductionServiceSystem.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.services.Implementations
{
    public class CityService : ICityService
    {
        private readonly CalculatorContext _context;
        public CityService(CalculatorContext calculator)
        {
            _context = calculator;
        }

        public OperationResultDTO AddCity(City city)
        {
            _context.City.Add(city);
            _context.SaveChanges();
         
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO DeleteCity(string cityName)
        {
            var city = GetCityByName(cityName);

            if (city == null)
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn`t exist" };

            _context.City.Remove(city);
            _context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationSuccesDTO<IList<City>> GetCities()
        {
            List<City> cities = _context.City.ToList();
            return new OperationSuccesDTO<IList<City>> { Message = "Success", Result = cities };
        }

        public City GetCityByName(string cityName) => _context.City.Where(x => x.Name == cityName).FirstOrDefault();

        public OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost)
        {
            var updateCity = _context.City.Where(x => x.Name == cityName).FirstOrDefault();
            if (updateCity == null)
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn`t exist" };

            updateCity.CostOfWorkingHour = workingHourCost;
            _context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO UpdateTransportCost(string cityName, double transportCost)
        {
            var updateCity = _context.City.Where(x => x.Name == cityName).FirstOrDefault();
            if (updateCity == null)
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName}, doesn`t exist." };

            updateCity.TransportCost = transportCost;
            _context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }
    }
}
