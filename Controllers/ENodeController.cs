using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc.Extensions;    
using Mon1.Models;

namespace Mon1.Controllers
{
    public class ENodeController : Controller
    {
        xxx
this looks suspicious
            xxx
#if false
        // these are unused  SourceCodeFile is from ~/Filters/SourceCodeFileAttribute.cs
       // [SourceCodeFile("EditableNodes (model)", "~/Models/EditableNodes.cs")]        
      // [SourceCodeFile("Editor.ascx (Editor)", "~/Views/Editor/EditorTemplates/Editor.ascx")]        
#if false
        public ActionResult EditorInGrid()  
        {
            var result = NodeRepository.All();
            return View("EditorInGrid",result);
        }        
#endif
        
        [AcceptVerbs(HttpVerbs.Post)]        
        public ActionResult UpdateNode(int id)        
        {            
            EditableNode theNode =  (EditableNode)NodeRepository.One(e => e.id == id);            
            if (TryUpdateModel(theNode))            
            {                
                // HTML decode the Notes property                
               theNode.notes = HttpUtility.HtmlDecode(theNode.notes);                
                NodeRepository.Update(theNode);                
                return View("EditorInGrid", this.GridRouteValues());            
                //return RedirectToAction("EditorInGrid", this.GridRouteValues());            
            }            
            return View("EditorInGrid", NodeRepository.All());        
        }    
    }
#endif
}
