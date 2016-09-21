using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataCostGroup
    {
        public static CostGroup GetCostGroup(Row row)
        {
            var costGroup = new CostGroup
            {
                Name = row["Kustannusryhmä"]               
            };

            return costGroup;
        }
    }
}