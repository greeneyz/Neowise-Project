using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataContract
    {
        public static Contract GetContract(Row row)
        {
            var contract = new Contract
            {
                ContractName = row["Liittymätyyppi"]                           
            };

            return contract;
        }
    }
}