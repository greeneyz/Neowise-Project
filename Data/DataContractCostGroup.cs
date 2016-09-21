using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataContractCostGroup
    {
        public static ContractCostGroup GetContractCostGroup(int ContractId, int CostGroupId)
        {
            var contractCostGroup = new ContractCostGroup
            {
                ContractId = ContractId,
                CostGroupId = CostGroupId,
            };

            return contractCostGroup;
        }
    }
}