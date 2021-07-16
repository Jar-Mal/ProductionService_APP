using ProductionServiceSystem.Models;
using ProductionServiceSystem.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.services.interfaces
{
    interface IModuleService
    {
        Module GetModuleByName(string moduleName);
        OperationSuccesDTO<List<Module>> GetModules();
        OperationSuccesDTO<Module> AddModule(Module module);
        OperationSuccesDTO<Module> UpdateModule(Module module);
        OperationSuccesDTO<Module> DeleteModule(string name);
    }
}
