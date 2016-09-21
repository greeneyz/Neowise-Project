using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataPackageSize
    {
        public static PackageSize GetPackageSize(Row row, int usageId)
        {
            var packageSize = new PackageSize
            {
               UsageId = usageId,
               Name = row["Paketin koko (kpl/min/Mt)"]
            };

            return packageSize;
        }
    }
}