using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionServiceSystem.Models;
using ProductionServiceSystem.ModelsDTO;

namespace ProductionServiceSystem.services.interfaces
{
    interface ICityService
    {
        City GetCityByName(string cityName);
        OperationSuccesDTO<IList<City>> GetCities();
        OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost);
        OperationResultDTO UpdateTransportCost(string cityName, double transportCost);
        OperationResultDTO AddCity(City city);
        OperationResultDTO DeleteCity(string cityName);

    }
}
