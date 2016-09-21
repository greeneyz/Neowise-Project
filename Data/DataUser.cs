using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;
using Neowise.DAL;

namespace Neowise.Data
{
    public class DataUser
    {
        public static User GetUser(Row row, int companyId)
        {
            var user = new User
            {
                 CompanyId =companyId,
                 Name = row["Käyttäjä"]
            };

            return user;
        }
    }
}