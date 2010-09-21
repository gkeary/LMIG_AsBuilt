using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mon1.Models
{
    public class SessionENodeRepository
    {

        public static NodeDataContext db = new NodeDataContext();

        public static IList<ENode> All()
        {
            IList<ENode> result = (from n in db.Nodes
                                   select new ENode
                                   {
                                       id = n.id,
                                       composite = n.composite,
                                       ip = n.ip,
                                       mname = n.mname,
                                       mhandle = n.mhandle,
                                       manu = n.manu,
                                       landscape = n.landscape,
                                       macaddress = (n.macaddress == "0") ? "" : n.macaddress,
                                       notes = n.notes
                                   }).ToList();

            return result;
        }

        public static Node OneNode(Func<Node, bool> predicate)
        {
            return db.Nodes.Where(predicate).FirstOrDefault();
        }

        public static ENode One(Func<ENode, bool> predicate)
        {
            return All().Where(predicate).FirstOrDefault();
        }

        public static void Update(ENode revised)
        {
            var text = revised.notes;

            var r = db.ExecuteCommand( @" Update dbo.spec set notes = {0} where id = {1} " , text, revised.id);
           
           Insert_audit(revised);
        }

        private static void Insert_audit(ENode revised)
        {
            var db = new auditDataContext();
            audit newaudit = new audit
            {
                ip = revised.ip,
                landscape = revised.landscape,
                macaddress = revised.macaddress,
                manu = revised.manu,
                mname = revised.mname,
                devicetype = revised.devicetype,
                notes = revised.notes,
                timestamp=DateTime.Now,
                username=System.Environment.UserName,
                mhandle=revised.mhandle 
            };

            db.audits.InsertOnSubmit(newaudit);
            db.SubmitChanges();
        }
    }
}