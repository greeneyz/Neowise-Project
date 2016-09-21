using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neowise.DAL;
using Neowise.Data;
using Neowise.Models;

namespace Neowise.Controllers
{
    public class ReportFiltersController : Controller
    {
        //
        // GET: /ReportFilters/

        NeowiseContext dataContext = new NeowiseContext();

        public ActionResult ReportInterface()
        {
            var filters = new FiltersModel();
            List<Company> allCompanies = dataContext.Company.ToList();
            Company firstCompany = new Company();
            firstCompany.Id = 0;
            firstCompany.CompanyName = "Select a company";
            allCompanies.Insert(0, firstCompany);

            List<Contract> allContracts = dataContext.Contract.ToList();
            Contract firstContract = new Contract();
            firstContract.Id = 0;
            firstContract.ContractName = "Select a contract type";
            allContracts.Insert(0, firstContract);


            List<User> allUsers = dataContext.User.Distinct().ToList();
            User firstUser = new DAL.User();
            firstUser.Id = 0;
            firstUser.Name = "Select a user";
            allUsers.Insert(0, firstUser);

            filters.CompanyList = allCompanies;
            filters.UserList = allUsers;
            filters.ContractList = allContracts;
            return View(filters);
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetContractsByCompany(int companyId)
        {
            var company = dataContext.Company.FirstOrDefault(com => com.Id == companyId);
            List<Contract> allContracts = new List<Contract>();
            if (company != null)
            {
                foreach (var companyContract in company.CompanyContractList)
                {
                    allContracts.Add(companyContract.Contract);
                }
            }
            /* Contract firstContract = new Contract();
             firstContract.Id = 0;
             firstContract.ContractName = "Select a contract type";
             allContracts.Insert(0, firstContract);*/
            SelectList objContracts = new SelectList(allContracts, "Id", "ContractName", 0);
            return Json(objContracts);
        }

        [HttpPost]
        public ActionResult GetUsersByContracts(int contractId)
        {
            var contract = dataContext.Contract.FirstOrDefault(c => c.Id == contractId);
            List<User> userList = new List<User>();
            if (contract != null)
            {
                var usageList = contract.ContractUsageList.ToList();
                foreach (var usage in usageList)
                {
                    userList.Add(usage.user);
                }
            }
            SelectList objUsers = new SelectList(userList.Distinct(), "Id", "Name", 0);
            return Json(objUsers);
        }

        public ActionResult GetContractReport()
        {
            var allContracts = dataContext.Contract.ToList();
            var lstContratcs = new List<ContractWiseReport>();

            for (int i = 0; i < allContracts.Count; i++)
            {
                var con = allContracts[i];
                var contractGroup = new ContractWiseReport();
                contractGroup.ContractName = con.ContractName;
                var lstUsage = dataContext.Usage.Where(usa => usa.ContractId == con.Id).ToList();
                var lstUsers = new List<ContractUserGroup>();
                double? totalCost = 0;
                foreach (var usag in lstUsage)
                {
                    var usr = new ContractUserGroup();
                    usr.UserName = usag.user.Name;
                    usr.PhoneNumber = usag.PhoneNumber;
                    usr.CompanyName = dataContext.Company.FirstOrDefault(c => c.Id == usag.CompanyId).CompanyName;
                    usr.Cost = usag.Cost;
                    totalCost = totalCost + usag.Cost;
                    lstUsers.Add(usr);
                }
                contractGroup.ContractUserList = lstUsers;
                contractGroup.TotalCostByContract = double.Parse(totalCost.ToString());
                lstContratcs.Add(contractGroup);
            }

            return View(lstContratcs);
        }

        [HttpPost]
        public ActionResult GetCompanyReport(int IdCompany, int IdContract, int IdUser)
        {

            if (IdUser == 0)
            {
                List<CompanyContracts> allContracts;
                var company = dataContext.Company.FirstOrDefault(com => com.Id == IdCompany);
                if (IdContract == 0)
                {
                    allContracts = company.CompanyContractList.ToList();
                }
                else
                {
                    allContracts = company.CompanyContractList.Where(c => c.ContractId == IdContract).ToList();
                }

                var lstContratcs = new List<ContractWiseReport>();

                for (int i = 0; i < allContracts.Count; i++)
                {
                    var con = allContracts[i];
                    var contractGroup = new ContractWiseReport();
                    contractGroup.CompanyName = company.CompanyName;
                    contractGroup.ContractName = con.Contract.ContractName;
                    var lstUsage = dataContext.Usage.Where(usa => usa.ContractId == con.Id).ToList();
                    var lstUsers = new List<ContractUserGroup>();
                    double? totalCost = 0;
                    foreach (var usag in lstUsage)
                    {
                        var usr = new ContractUserGroup();
                        usr.UserName = usag.user.Name;
                        usr.PhoneNumber = usag.PhoneNumber;
                        usr.CompanyName = dataContext.Company.FirstOrDefault(c => c.Id == usag.CompanyId).CompanyName;
                        usr.Cost = usag.Cost;
                        totalCost = totalCost + usag.Cost;
                        lstUsers.Add(usr);
                    }
                    contractGroup.ContractUserList = lstUsers;
                    contractGroup.TotalCostByContract = double.Parse(totalCost.ToString());
                    lstContratcs.Add(contractGroup);
                }
                return View("GetContractReport", lstContratcs);
            }
            else
            {
                UserReportModel usrRpt = new UserReportModel();
                var user = dataContext.User.FirstOrDefault(u => u.Id == IdUser);
                usrRpt.CompanyName = dataContext.Company.FirstOrDefault(com => com.Id == IdCompany).CompanyName;
                usrRpt.UserName = user.Name;
                double? totalCost = 0;
                var lstContracts = new List<UserContracts>();
                foreach (var usr in user.ContractUsageList)
                {
                    var ctr = new UserContracts();
                    ctr.ContractName = usr.Contract.ContractName;
                    ctr.Cost = usr.Cost;
                    totalCost = totalCost + usr.Cost;
                    ctr.DataTransfer = usr.DataTransferInMb;
                    ctr.Minutes = usr.Minutes;
                    ctr.PackageUsagePercentage = usr.PackageUsagePercentage;
                    ctr.PhoneNumber = usr.PhoneNumber;
                    ctr.Quantity = usr.Quantity;
                    lstContracts.Add(ctr);
                }
                usrRpt.TotalCost = totalCost;
                usrRpt.UserUsage = lstContracts;
                return View("UserReport", usrRpt);
            }
        }

        [HttpPost]
        public ActionResult GetReportByPhone(string phoneNumber)
        {
            var usage = dataContext.Usage.FirstOrDefault(us => us.PhoneNumber == phoneNumber);
            UserReportModel usrRpt = new UserReportModel();
            if (usage != null)
            {
                var user = usage.user;               
                usrRpt.CompanyName = dataContext.Company.FirstOrDefault(com => com.Id == user.CompanyId).CompanyName;
                usrRpt.UserName = user.Name;
                double? totalCost = 0;
                var lstContracts = new List<UserContracts>();
                foreach (var usr in user.ContractUsageList)
                {
                    var ctr = new UserContracts();
                    ctr.ContractName = usr.Contract.ContractName;
                    ctr.Cost = usr.Cost;
                    totalCost = totalCost + usr.Cost;
                    ctr.DataTransfer = usr.DataTransferInMb;
                    ctr.Minutes = usr.Minutes;
                    ctr.PackageUsagePercentage = usr.PackageUsagePercentage;
                    ctr.PhoneNumber = usr.PhoneNumber;
                    ctr.Quantity = usr.Quantity;
                    lstContracts.Add(ctr);
                }
                usrRpt.TotalCost = totalCost;
                usrRpt.UserUsage = lstContracts;
                return View("UserReport", usrRpt);
            }
            else
                return View("UserReport", usrRpt);
        }

    }
}
