using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionServiceSystem.ModelsDTO
{
    public class OperationSuccesDTO<T> : OperationResultDTO
        where T : class
    {
        public T Result { get; set; }
    }
}
