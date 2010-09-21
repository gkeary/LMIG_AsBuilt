using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mon1.Models;
using Telerik.Web.Mvc.Extensions;

namespace Mon1.Controllers.Editor
{
    public partial class EditorController : Controller
    {
        public ActionResult EditorInGrid()
        {
            return View(SessionENodeRepository.All());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateNode(int id)
        {
            ENode enode = SessionENodeRepository.One(e => e.id == id);
            if (TryUpdateModel(enode))
            {
                // HTML decode the Notes property
                enode.notes = HttpUtility.HtmlDecode(enode.notes);
                // this needs some work..  try doing something in the powershell...
                // symptom:  <p>  and </p> are showing up in the audit table 
               // enode.notes = enode.notes.Replace("<p>", "");
               // enode.notes = enode.notes.Replace("</p>", "\r\n");
               // enode.notes = enode.notes.Replace("|", "\r\n");

                SessionENodeRepository.Update(enode);

                return RedirectToAction("EditorInGrid", this.GridRouteValues());
            }

            return View("EditorInGrid", SessionENodeRepository.All());
        }

    }
}