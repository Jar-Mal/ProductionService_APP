using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionServiceSystem.ModelsDTO;

namespace ProductionServiceSystem.services.interfaces
{
    public interface IShowResultService
    {
        ResultCostDTO PresentResult(string cityName, ModuleListDTO moduleListDTO);
    }
}
