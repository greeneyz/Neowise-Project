using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.DAL
{
    public class ContractCostGroup
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int CostGroupId { get; set; }

        public virtual Contract Contract{ get; set; }
        public virtual CostGroup CostGroup { get; set; }
    }
}