using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.Models
{
    public class ContractWiseReport
    {
        public string CompanyName { get; set; }
        public string ContractName { get; set; }
        public List<ContractUserGroup> ContractUserList{ get; set; }
        public double TotalCostByContract { get; set; }       
    }

    public class ContractUserGroup
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public double? Cost { get; set; }
    }
}