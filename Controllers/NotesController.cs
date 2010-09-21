using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mon1.Models;
using Telerik.Web.Mvc.Extensions;

namespace Mon1.Controllers
{
    public class NotesController : Controller
    {
            [HandleError]
            public ActionResult Index()
            {
                var result = NodeRepository.All();
                return View(result);
            }

            public ActionResult EditorInGrid()
            {
                var result = NodeRepository.All();
                return View(result);
            }
/***
            private Node EditGrid(int? id)
            {
                var db = new NodeDataContext();
                Node nodeToEdit = (from n in db.Nodes
                                   select n).FirstOrDefault(n => n.id == id);
                return nodeToEdit;
            }
            //
            // GET: /Home/Edit/5

            public ActionResult Edit(int id)
            {
                var db = new NodeDataContext();
                var nodeToEdit = (from n in db.Nodes
                                  where n.id == id
                                  select n).FirstOrDefault();

                return RedirectToAction("NoteEdit", nodeToEdit);
            }
            private Node Edit(int? id)
            {
                var db = new NodeDataContext();
                var node = (from n in db.Nodes
                            where n.id == id
                            select n).FirstOrDefault();
                return node;
            }

            //
            // POST: /Home/Edit/5

        //old
            [AcceptVerbs(HttpVerbs.Post)]
            [HandleError]
            public ActionResult Edit(EditableNode revised)
            {
                if (!ModelState.IsValid)
                    return View(revised);

                try
                {
                    var db = new NodeDataContext();
                    var orig = (from n in db.Nodes
                                where n.id == revised.id
                                select n).FirstOrDefault();

                    orig.notes = revised.notes;
                    orig.mname = revised.mname;
                    db.SubmitChanges();
                    PSset_note(revised);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewData["Post"] = e.Message;
                    return View();
                }
            }
 * ************/
        // new
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult UpdateNode(int id)
            {
                EditableNode theNode = (EditableNode)NodeRepository.One(e => e.id == id);
                if (TryUpdateModel(theNode))
                {
                    // HTML decode the Notes property                
                    theNode.notes = HttpUtility.HtmlDecode(theNode.notes);
                    NodeRepository.Update(theNode);
                    return RedirectToAction("EditorInGrid", this.GridRouteValues());
                }
                return View("EditorInGrid", NodeRepository.All());
            }

            private void PSset_note(EditableNode orig)
            {
                //var shfile = "e:\\clikit\\vnmsh\\setnote.sh";
                var shfile = "c:\\temp\\setnote.sh";
                string mh = orig.mhandle;
                var ls = orig.landscape;
                var newtext = orig.notes;

                var sb = new System.Text.StringBuilder();

                mh = ls = ""; // for debugging only
                if (mh == "") { mh = "0x8b9e84"; }
                if (ls == "") { ls = "artemis"; }
                if (newtext == "") { newtext = "Default from||gregg"; }

                sb.AppendLine("CLISESSID=$$");
                sb.AppendLine("export CLISESSID");
                sb.AppendLine("cd e:");
                sb.AppendLine("cd clikit/vnmsh");
                sb.Append("./connect.exe ");
                sb.Append(ls);
                sb.Append("\r\n");
                sb.Append("./update.exe mh=");
                sb.Append(mh);
                sb.AppendLine(" attr=0x12c00,val=Exclusion");
                sb.Append("./update.exe mh=");
                sb.Append(mh);
                sb.Append(" attr=0x11564,val=");
                newtext = newtext.Replace("\"", " ");
                sb.Append("\"");
                sb.Append(newtext);
                sb.Append("\"");
                sb.AppendLine("\r\n");
                var ShellString = sb.ToString();
                if (System.IO.File.Exists(shfile))
                {
                    System.IO.File.Delete(shfile);
                }
                System.IO.File.WriteAllText(shfile, ShellString);
                try
                {
                    //System.IO.File.WriteAllText("c:\\temp\\setnote.sh", ShellString);
                }
                catch (Exception e)
                {
                    ViewData["WriteAllText"] = e.Message;
                }

                var result = CLI.CLITask.Execute(ls, mh, newtext);
                try
                {
                    //var result = CLI.CLITask.Execute(ShellString);
                }
                catch (Exception e)
                {
                    ViewData["Start"] = e.Message;
                }
            }
        }
    }
