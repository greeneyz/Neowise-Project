using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using LinqToExcel;

namespace Neowise.Data
{
    public class ImportInvoiceData
    {
        public static void ImportInvoices(string serverPath)
        {
           // string path = Path.Combine(serverPath, "Data", "Invoices.xlsx");
            NeowiseContext dataContext = new NeowiseContext();
            string sheetName = "Data";

            var excelFile = new ExcelQueryFactory(serverPath);
            var contracts = from UserContracts in excelFile.Worksheet(sheetName) select UserContracts;

            foreach (var row in contracts)
            {
                var company = DataCompany.GetCompany(row);
                var isCompanyExists =  dataContext.Company.FirstOrDefault(c=> c.CompanyName==company.CompanyName);
                if (isCompanyExists == null)
                {
                    dataContext.Company.Add(company);
                    dataContext.SaveChanges();
                }
                else
                    company = isCompanyExists;
               
                var user = DataUser.GetUser(row, dataContext.Company.ToList().LastOrDefault().Id);
                var isUserExists = dataContext.User.FirstOrDefault(u => u.Name == user.Name);
                if (isUserExists == null){
                    dataContext.User.Add(user);
                    dataContext.SaveChanges();
                }
                else
                    user = isUserExists;

                var contract = DataContract.GetContract(row);
                var isContractExists = dataContext.Contract.FirstOrDefault(u => u.ContractName == contract.ContractName);
                if (isContractExists == null){
                    dataContext.Contract.Add(contract);
                    dataContext.SaveChanges();
                }
                else
                    contract = isContractExists;

                var companyContract = DataCompanyContract.GetComapnyContract(dataContext.Company.ToList().LastOrDefault().Id, dataContext.Contract.ToList().LastOrDefault().Id);
                var isCompanyContractExists = dataContext.CompanyContracts.FirstOrDefault(u => u.ContractId == companyContract.ContractId && u.CompanyId == companyContract.CompanyId);
                if (isCompanyContractExists == null){
                    dataContext.CompanyContracts.Add(companyContract);
                    dataContext.SaveChanges();
                }

                var costGroup = DataCostGroup.GetCostGroup(row);
                var isCostGroupExists = dataContext.CostGroup.FirstOrDefault(u => u.Name.Equals(costGroup.Name));
                if (isCostGroupExists == null){
                    dataContext.CostGroup.Add(costGroup);
                    dataContext.SaveChanges();
                }
                else
                    costGroup = isCostGroupExists;

                var contractCostGroup = DataContractCostGroup.GetContractCostGroup(dataContext.Contract.ToList().LastOrDefault().Id, dataContext.CostGroup.ToList().LastOrDefault().Id);
                var isContractCostGroupExists = dataContext.ContractCostGroup.FirstOrDefault(u => u.ContractId == contractCostGroup.ContractId && u.CostGroupId == contractCostGroup.CostGroupId);
                if (isContractCostGroupExists == null){
                    dataContext.ContractCostGroup.Add(contractCostGroup);
                    dataContext.SaveChanges();
                }

                var costType = DataCostType.GetCostType(row);
                var iscostTypeExists = dataContext.CostType.FirstOrDefault(u => u.Name.Equals(costType.Name));
                if (iscostTypeExists == null){
                    dataContext.CostType.Add(costType);
                    dataContext.SaveChanges();
                }
                else
                    costType = iscostTypeExists;

                var contractCostType = DataContractCostType.GetContractCostType(dataContext.Contract.ToList().LastOrDefault().Id, dataContext.CostType.ToList().LastOrDefault().Id);
                var isContractCostTypeExists = dataContext.ContractCostType.FirstOrDefault(u => u.ContractId == contractCostGroup.ContractId && u.CostTypeId == contractCostType.CostTypeId);
                if (isContractCostTypeExists == null){
                    dataContext.ContractCostType.Add(contractCostType);
                    dataContext.SaveChanges();
                }


                var usage = DataUsage.GetUsage(row, dataContext.Contract.ToList().LastOrDefault().Id, dataContext.Company.ToList().LastOrDefault().Id, dataContext.User.ToList().LastOrDefault().Id);
                var isUsageExists = dataContext.Usage.FirstOrDefault(u => u.ContractId == usage.ContractId && u.CompanyId == company.Id && u.UserId == user.Id);
                if (isUsageExists == null){
                    dataContext.Usage.Add(usage);
                    dataContext.SaveChanges();
                }
                else
                    usage = isUsageExists;

                var packageSize = DataPackageSize.GetPackageSize(row, dataContext.Usage.ToList().LastOrDefault().Id);
                var ispackageSizeExists = dataContext.PackageSize.FirstOrDefault(u => u.UsageId == packageSize.UsageId);
                if (ispackageSizeExists == null)
                    dataContext.PackageSize.Add(packageSize);

                dataContext.SaveChanges();
                //string artistInfo = "Artist Name: {0}; Album: {1}";
                //Console.WriteLine(string.Format(artistInfo, cont["Name"], cont["Title"]));
            }

        }
    }
}