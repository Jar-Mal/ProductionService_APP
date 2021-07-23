using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionServiceSystem.ModelsDTO;
using ProductionServiceSystem.Models;

namespace ProductionServiceSystem.services.interfaces
{
    public interface ISearchHistoryService
    {
        ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO);
        OperationSuccesDTO<IList<SearchHistory>> GetSearchHistories();
        OperationResultDTO AddSearchHistory(SearchHistory searchHistory);

    }
}
