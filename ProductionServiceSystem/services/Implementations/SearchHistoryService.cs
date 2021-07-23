using ProductionServiceSystem.Models;
using ProductionServiceSystem.ModelsDTO;
using ProductionServiceSystem.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.services.Implementations
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly CalculatorContext _context;
        private readonly IModuleService _moduleService;
        private readonly ICityService _cityService;

        public SearchHistoryService(CalculatorContext context, IModuleService moduleService, ICityService cityService)
        {
            _context = context;
            _moduleService = moduleService;
            _cityService = cityService;
        }


        public OperationResultDTO AddSearchHistory(SearchHistory searchHistory)
        {
            _context.SearchHistory.Add(searchHistory);
            _context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Succes" };
        }


        public OperationSuccesDTO<IList<SearchHistory>> GetSearchHistories()
        {
            List<SearchHistory> searchHistories = _context.SearchHistory.ToList();
            return new OperationSuccesDTO<IList<SearchHistory>> { Message = "Success", Result = searchHistories };
        }

        public ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = _cityService.GetCityByName(cityName);

            if (city == null) return new ResultCostDTO { InSearchHistory = false };

            var searchHistoryList = _context.SearchHistory.Where(x => x.CityId == city.Id);

            if (searchHistoryList == null) return new ResultCostDTO { InSearchHistory = false };

            int counterModule = 0;

            foreach (SearchHistory searchHistory in searchHistoryList)
            {
                counterModule = 0;

                foreach (string searchHistoryPar in moduleListDTO.ModuleList)
                {
                    if (searchHistory.ModuleName1 == searchHistoryPar ||
                        searchHistory.ModuleName2 == searchHistoryPar ||
                        searchHistory.ModuleName3 == searchHistoryPar ||
                        searchHistory.ModuleName4 == searchHistoryPar)
                    {
                        counterModule++;
                    }
                    else break;
                }
                if (moduleListDTO.ModuleList.Count() == ModuleHasValue(searchHistory) &&
                    moduleListDTO.ModuleList.Count() == counterModule)
                    return new ResultCostDTO { InSearchHistory = true, Cost = searchHistory.ProductionCost };
            }
            return new ResultCostDTO { InSearchHistory = false };
        }

        private int ModuleHasValue(SearchHistory searchHistory)
        {
            int counter = 0;
            if (!(searchHistory.ModuleName1 == string.Empty))
                counter++;
            if (!(searchHistory.ModuleName2 == string.Empty))
                counter++;
            if (!(searchHistory.ModuleName3 == string.Empty))
                counter++;
            if (!(searchHistory.ModuleName4 == string.Empty))
                counter++;
            return counter;
        }


    }
}
