using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataUsage
    {
        public static Usage GetUsage(Row row, int contractId,int companyId, int userId)
        {
           double cost;
           double.TryParse(row["€/kk"], out cost);
           var cultureFreecost = double.Parse(cost.ToString(CultureInfo.InstalledUICulture));

           int usagePercent;
           int.TryParse(row["Paketin käyttöaste %"], out usagePercent);
           var cultureFreeUsagePercent = int.Parse(usagePercent.ToString(CultureInfo.InstalledUICulture));


           int quantity;
           int.TryParse(row["Kappaleet"], out quantity);
           var cultureFreeQuantity = int.Parse(quantity.ToString(CultureInfo.InstalledUICulture));

           double minutes;
           double.TryParse(row["Minuutit"], out minutes);
           var cultureFreeMinutes = double.Parse(minutes.ToString(CultureInfo.InstalledUICulture));

           double dataTransfer;
           double.TryParse(row["Siirretty data Mt"], out dataTransfer);
           var cultureFreedataTransfer = double.Parse(dataTransfer.ToString(CultureInfo.InstalledUICulture));
              
            var usage = new Usage
            {
               ContractId = contractId,
               CompanyId = companyId,
               UserId = userId,
               PhoneNumber = row["Numero"],
               Cost = cultureFreecost,
               Quantity = cultureFreeQuantity,
               Minutes = cultureFreeMinutes,
               DataTransferInMb = cultureFreedataTransfer,
               PackageUsagePercentage = cultureFreeUsagePercent
            };

            return usage;
        }
    }
}