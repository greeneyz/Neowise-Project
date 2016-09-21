using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.DAL
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<CompanyContracts> CompanyContractList { get; set; }
        public virtual ICollection<User> UsersList { get; set; }
    }
}