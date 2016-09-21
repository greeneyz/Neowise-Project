using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Neowise.DAL;

namespace Neowise.Data
{
    public class NeowiseContext:DbContext
    {
        public NeowiseContext()
            : base("NeowiseContextString")
        {
            
        }
        
        public DbSet<Company> Company { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Usage> Usage { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<CompanyContracts> CompanyContracts { get; set; }
        public DbSet<CostType> CostType { get; set; }
        public DbSet<ContractCostType> ContractCostType { get; set; }
        public DbSet<CostGroup> CostGroup { get; set; }
        public DbSet<ContractCostGroup> ContractCostGroup { get; set; }
        public DbSet<PackageSize> PackageSize { get; set; }

    }
}