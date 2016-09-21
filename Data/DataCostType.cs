using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataCostType
    {
        public static CostType GetCostType(Row row)
        {
            var costType = new CostType
            {
                Name = row["Kustannuslaji"]
            };

            return costType;
        }
    }
}