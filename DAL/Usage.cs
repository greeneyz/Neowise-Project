using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.DAL
{
    public class Usage
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int? PackageUsagePercentage { get; set; }
        public double? Cost { get; set; }
        public int Quantity { get; set; }
        public double? Minutes { get; set; }
        public double? DataTransferInMb { get; set; }
        public virtual User user { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ICollection<PackageSize> PackageSizeList { get; set; }
        
    }
}