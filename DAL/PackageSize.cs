using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neowise.DAL
{
    public class PackageSize
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsageId { get; set; }
        public virtual Usage Usage { get; set; }
    }
}