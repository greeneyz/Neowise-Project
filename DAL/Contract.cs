using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.DAL
{
    public class Contract
    {
        public int Id { get; set; }
        public string ContractName { get; set; }
        public virtual ICollection<Usage> ContractUsageList { get; set; }
        public virtual ICollection<CompanyContracts> CompanyList { get; set; }
        public virtual ICollection<ContractCostGroup> CostGroupList { get; set; }
        public virtual ICollection<ContractCostType> CostTypeList { get; set; }
    }
}