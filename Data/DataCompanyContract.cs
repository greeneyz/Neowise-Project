using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataCompanyContract
    {
        public static CompanyContracts GetComapnyContract(int CompanyId, int ContractId)
        {
            var companyContracts = new CompanyContracts
            {
                CompanyId = CompanyId,
                ContractId = ContractId
                
            };

            return companyContracts;
        }
    }
}