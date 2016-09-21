using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.DAL
{
    public class ContractCostType
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int CostTypeId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual CostType CostType { get; set; }
    }
}
