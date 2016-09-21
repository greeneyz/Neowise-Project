using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataCompany
    {
        public static Company GetCompany(Row row)
        {
            var company = new Company
            {
                CompanyName = row["Yritys"]
            };

            return company;
        }
    }
}