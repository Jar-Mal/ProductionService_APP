using Microsoft.AspNetCore.Mvc;
using ProductionServiceSystem.Models;
using ProductionServiceSystem.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.Controllers
{
    public class ModulesController : Controller
    {
        private readonly IModuleService _moduleService;

        public ModulesController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        [Route("Modules/GetModules")]
        public IActionResult GetModules() => Ok(_moduleService.GetModules().Result);

        [HttpGet]
        [Route("Modules/GetModuleByName/{name}")]
        public IActionResult GetModuleByName(string name) => name == null ? NotFound() : Ok(_moduleService.GetModuleByName(name));

        [HttpPut]
        [Route("Module/UpdateModule")]
        public IActionResult UpdateModule(Module module) => Ok(_moduleService.UpdateModule(module).Message);

        [HttpPost]
        [Route("Module/AddModule")]
        public IActionResult AddModule(Module module) => Ok(_moduleService.AddModule(module).Message);

        [HttpDelete]
        [Route("Module/DeleteModule/{name}")]
        public IActionResult DeleteModule(string name) => Ok(_moduleService.DeleteModule(name).Message);

    }
}
