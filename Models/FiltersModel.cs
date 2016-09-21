using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neowise.DAL;

namespace Neowise.Models
{
    public class FiltersModel
    {
        public IEnumerable<Company> CompanyList { get; set; }
        public List<Contract> ContractList { get; set; }
        public List<User> UserList { get; set; }
    }
}