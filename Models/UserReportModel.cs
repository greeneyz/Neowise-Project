using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.Models
{
    public class UserReportModel
    {
        public string CompanyName { get; set; }
        public string UserName { get; set; }             
        public double? TotalCost { get; set; }
        public List<UserContracts> UserUsage { get; set; }

    }

    public class UserContracts 
    {
        public string ContractName { get; set; }  
        public string PhoneNumber { get; set; }
        public int? PackageUsagePercentage { get; set; }
        public double? Cost { get; set; }
        public int? Quantity { get; set; }
        public double? Minutes { get; set; }
        public double? DataTransfer { get; set; }
    }
}