using Microsoft.AspNetCore.Mvc;
using ProductionServiceSystem.services.interfaces;
using ProductionServiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.Controllers
{
    public class SearchHistoryController : Controller
    {
        private readonly ISearchHistoryService _searchHistoryService;

        public SearchHistoryController(ISearchHistoryService searchHistoryService)
        {
            _searchHistoryService = searchHistoryService;
        }

        [HttpGet]
        [Route("SearchHistories/GetSearchHistory")]
        public IActionResult GetSearchHistory() => Ok(_searchHistoryService.GetSearchHistories().Result);

        [HttpPost]
        [Route("SearchHistories/AddSearchHistory")]
        public IActionResult AddSearchHistory(SearchHistory searchHistory)
        {
            if (searchHistory == null)
                return BadRequest("Object Search history is null.");

            var response = _searchHistoryService.AddSearchHistory(searchHistory);

            if (response.Message.Equals("Success"))
                return Ok("Success");
            return BadRequest("Error!");
        }



    }
}
