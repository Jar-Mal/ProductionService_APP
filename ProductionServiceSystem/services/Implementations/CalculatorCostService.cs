using ProductionServiceSystem.ModelsDTO;
using ProductionServiceSystem.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.services.Implementations
{
    public class CalculatorCostService : ICalculatorCostService
    {

        private readonly CalculatorCostService _context;
        private readonly ICityService _cityService;
        private readonly IModuleService _moduleService;
        private readonly ISearchHistoryService _searchHistoryService;

        public CalculatorCostService(CalculatorCostService context,
                                     ICityService cityService,
                                     IModuleService moduleService,
                                     ISearchHistoryService searchHistoryService)
        {
            _context = context;
            _cityService = cityService;
            _moduleService = moduleService;
            _searchHistoryService = searchHistoryService;
        }

        public OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = _cityService.GetCityByName(cityName);

            if (city == null)
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn`t exist" };

            var moduleCost = city.TransportCost;
            foreach (String moduleName in moduleListDTO.ModuleList)
            {
                var module = _moduleService.GetModuleByName(moduleName);

                if (module == null)
                    return new OperationErrorDTO { Code = 404, Message = $"Module with name: {moduleName} doesn`t exist" };
                moduleCost = moduleCost + module.Price + (module.AssemblyTime * city.CostOfWorkingHour);
            }
            moduleCost = moduleCost * 1.3;
            return new OperationSuccesDTO<ResultCostDTO>
            {
                Message = "Success",
                Result = new ResultCostDTO { Cost = moduleCost, InSearchHistory = false }
            };
        }
    }
}
