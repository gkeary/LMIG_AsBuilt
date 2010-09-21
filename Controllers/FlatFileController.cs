using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mon1.Models;
using System.IO;
using System.Text;
using Telerik.Web.Mvc;
using Telerik.Web.Mvc.Extensions;

namespace Mon1.Controllers
{
   public class FlatFileController : Controller
    { 
        
        public ActionResult CustomCommand()
        {
            var db = new asaDataContext();
            return View(db.asas.ToList<asa>());
            
        }

        [GridAction]
        public ActionResult _CustomCommand()
        {
            var db = new asaDataContext();
            return View(db.asas.ToList<asa>());
        }

        public ActionResult ExportCsv(int page, string orderBy, string filter)
        {
            var db = new asaDataContext();
            IQueryable<asa> assets = (IQueryable<asa>) db.asas.AsQueryable().ToGridModel(page, 50000, orderBy, string.Empty, filter).Data;

            MemoryStream output = new MemoryStream();
            StreamWriter writer = new StreamWriter(output, Encoding.UTF8);

            writer.Write("id,"); 
            writer.Write("businessowner,");
            writer.Write("servername,"); 
            writer.Write("ismonitored,");
            writer.Write("toolname,");
            writer.Write("whyunmonitored,");
            writer.Write("environment,");
            writer.Write("nodetype,");
            writer.Write("framename,");
            writer.Write("datacenter,");
            writer.Write("hardwaremodel,");
            writer.Write("os,");
            writer.Write("serialnumber,");
            writer.Write("servereol,");
            writer.Write("installdate,");
            writer.Write("lastupdated");
            writer.WriteLine();

            foreach (var a in assets)
            {

            writer.Write("\""); writer.Write(a.id);  writer.Write("\",");
            writer.Write("\""); writer.Write(a.businessowner); writer.Write("\",");
            writer.Write("\""); writer.Write(a.servername); writer.Write("\",");
            writer.Write("\""); writer.Write(a.ismonitored); writer.Write("\",");
            writer.Write("\""); writer.Write(a.toolname); writer.Write("\",");
            writer.Write("\""); writer.Write(a.whyunmonitored); writer.Write("\",");
            writer.Write("\""); writer.Write(a.environment); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.nodetype); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.framename); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.datacenter); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.hardwaremodel); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.os); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.serialnumber); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.servereol); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.installdate); writer.Write("\","); 
            writer.Write("\""); writer.Write(a.lastupdated); writer.Write("\""); 
            writer.WriteLine();
            }

            writer.Flush();
            output.Position = 0;
            
            return File(output, "text/comma-separated-values", "CoverageGrid.csv");
        }
    }
}
