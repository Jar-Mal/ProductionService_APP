using Microsoft.AspNetCore.Mvc;
using ProductionServiceSystem.Models;
using ProductionServiceSystem.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductionServiceSystem.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        [Route("Cities/GetCities")]
        public IActionResult GetCitites()
        {
            return Ok(_cityService.GetCities().Result);
        }

        [HttpGet]
        [Route("Cities/GetCityByName/{name}")]
        // [ProducesDefaultResponseType(typeof(City))]
        public IActionResult GetCityByName(string name)
        {
            City city = _cityService.GetCityByName(name);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPut]
        [Route("Cities/UpdateTransportCost")]
        public IActionResult UpdateTransportCost(City city)
        {
            var response = _cityService.UpdateTransportCost(city.Name, city.TransportCost);
            if (response.Message.Equals("Success"))
                return Ok(response.Message);

            return BadRequest(response.Message);
        }

        [HttpPut]
        [Route("Cities/UpdateCostOfWorkingHour")]
        public IActionResult UpdateCostOfWorkingHour(City city)
        {
            var response = _cityService.UpdateCostOfWorkingHour(city.Name, city.CostOfWorkingHour);
            if (response.Message.Equals("Success"))
                return Ok(response.Message);
            return BadRequest(response.Message);
        }

        [HttpPost]
        [Route("Cities/AddCity")]
        public IActionResult AddCity(City city)
        {
            if (city == null)
                return BadRequest("Object is null.");
            var response = _cityService.AddCity(city);

            if (response.Message.Equals("Success"))
                return Ok(response.Message);

            return BadRequest("Error");
        }
        [HttpDelete]
        [Route("Cities/DeleteCity/{name}")]
        public IActionResult DeleteCity(string name)
        {
            if (name == null)
                return BadRequest("City name is null.");

            var response = _cityService.DeleteCity(name);
            if (response.Message.Equals("Success"))
                return Ok(response.Message);
            
            return BadRequest("Error");
        }
    }
}
