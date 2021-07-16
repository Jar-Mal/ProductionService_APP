using ProductionServiceSystem.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.services.interfaces
{
    interface ICalculatorCostService
    {
        OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO);
    }
}
