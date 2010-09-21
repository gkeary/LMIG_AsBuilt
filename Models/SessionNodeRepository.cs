using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mon1.Models
{
    public class SessionNodeRepository
    {
        public static IList<EditableNode> All() {  
            
            IList<EditableNode> result = ( IList<EditableNode> )HttpContext.Current.Session[ "Nodes" ];

            if ( result == null )
            {
                HttpContext.Current.Session[ "Nodes" ] = result =
                    ( from n in new NodeDataContext().Nodes
                      select new EditableNode
                      {
                          id = n.id,
                          ip = n.ip,
                          mname = n.mname,
                          manu= n.manu,
                          landscape=n.landscape,
                          macaddress=n.macaddress,
                          notes=n.notes
                      } ).ToList();
            }

            return result; }
#if false
        public static EditableNode One(Func<EditableNode,bool> predicate) 
        { 
                      return  All().Where(predicate).FirstOrDefault();
        }
        public static void Update(EditableNode source)
        {
            EditableNode target = (EditableNode)One(e => e.id == source.id);
            if (target != null)
            {
                          target.id = source.id;
                          target.ip = source.ip;
                          target.mname = source.mname;
                          target.manu= source.manu;
                          target.landscape=source.landscape;
                          target.macaddress=source.macaddress;
                          target.notes=source.notes;
            }
        }
#endif
    }
}