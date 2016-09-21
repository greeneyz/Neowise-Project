using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataContractCostType
    {
        public static ContractCostType GetContractCostType(int ContractId, int costTypeId)
        {
            var contractCostType = new ContractCostType
            {
                 ContractId = ContractId,
                 CostTypeId = costTypeId,
            };

            return contractCostType;
        }
    }
}