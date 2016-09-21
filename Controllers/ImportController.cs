using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neowise.Data;

namespace Neowise.Controllers
{
    public class ImportController : Controller
    {
        //
        // GET: /Import/

        public ActionResult ImportData()
        {
            return View();
        }

        /*  public JsonResult StartImporting()
          {
              var path = Server.MapPath("~/bin");
              ImportInvoiceData.ImportInvoices(path);
              return new JsonResult()
              {
                  Data = "Data has been imported successfully."
              };
          }*/

        [HttpPost]
        public ActionResult StartImporting(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);

                //var importedFilePath = Server.MapPath("~/App_Data/uploads");
                ImportInvoiceData.ImportInvoices(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
    }
}
