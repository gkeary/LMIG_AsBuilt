using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mon1.Models
{
    public static class NodeRepository
    {

        private static NodeDataContext db = new NodeDataContext();
  
        public static IList<EditableNode> All()
        {

            IList<EditableNode> result = (IList<EditableNode>)HttpContext.Current.Session["Nodes"];

            if (result == null)
            {
                HttpContext.Current.Session["Nodes"] = result =
                    (from n in new NodeDataContext().Nodes
                     select new EditableNode
                     {
                         id = n.id,
                         ip = n.ip,
                         mname = n.mname,
                         manu = n.manu,
                         landscape = n.landscape,
                         macaddress = n.macaddress,
                         notes = n.notes
                     }).ToList();
                foreach (var a in result)
                {
                    a.macaddress = (a.macaddress == "0") ? "" : a.macaddress;
                    a.notes = (a.notes == null) ? "" : fixup(a.notes);
                }
            }

            return result;
        }

        // hook for call to powershell
        public static string CLIWrite()
        {
            /**********
             * try 
             * System.Diagnostics.process.Start( @" path to file here " );
             * 
           *****************/
            throw new NotImplementedException();
        }

        public static Exception NotImplemented { get; set; }

        // replace pipes with <CRLF>
        // Todo: change <CR> to '0d0a' ...
        private static string fixup(string n)
        {
            const string crlf = "\r\n";
            if (n.Contains('|'))
            { return n.Replace("|", crlf); }
            else { return n; }
        }


        public static Node One(Func<Node, bool> predicate)
        {
            return new EditableNode(); // All().Where(predicate).FirstOrDefault();
        }

        internal static void Update(EditableNode target)
        {
            //EditableNode target = (EditableNode)One(e => e.id == source.id);
            if (target != null)
            {
                var him = db.Nodes.Where(w => w.id == target.id).FirstOrDefault();
                him.notes = target.notes;
                db.SubmitChanges();
            }
        }
    }
}