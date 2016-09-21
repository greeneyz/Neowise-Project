using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.DAL
{
    public class CompanyContracts
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int CompanyId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Company Company { get; set; }
    }
}