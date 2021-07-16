using ProductionServiceSystem.Models;
using ProductionServiceSystem.ModelsDTO;
using ProductionServiceSystem.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.services.Implementations
{
    public class ModuleService : IModuleService
    {
        private readonly CalculatorContext _context;

        public ModuleService(CalculatorContext context)
        {
            _context = context;
        }

        public OperationSuccesDTO<Module> AddModule(Module module)
        {
            _context.Module.Add(module);
            _context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationSuccesDTO<Module> DeleteModule(string name)
        {
            var module = _context.Module.Where(module => module.Name == name).FirstOrDefault();
            _context.Module.Remove(module);
            _context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public Module GetModuleByName(string moduleName) => _context.Module.Where(module => module.Name == moduleName).FirstOrDefault();

        public OperationSuccesDTO<List<Module>> GetModules()
        {
            List<Module> modules = _context.Module.ToList();
            return new OperationSuccesDTO<List<Module>> { Message = "Success", Result = modules };
        }

        public OperationSuccesDTO<Module> UpdateModule(Module module)
        {
            var mod = _context.Module.Where(m => m.Name == module.Name).FirstOrDefault();
            mod = module;
            _context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };

        }
    }
}
