using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionServiceSystem.services.interfaces;
using ProductionServiceSystem.Models;

namespace ProductionServiceSystem.Controllers
{
    public class ShowResultController : Controller
    {
        private readonly IShowResultService _showResultService;
        public ShowResultController(IShowResultService showResultService)
        {
            _showResultService = showResultService;
        }

        //[HttpPost]
        //[Route("ShowResult/Get")]
        //public IActionResult GetCost(ShowResultDTO showResultDTO)
    }

}
