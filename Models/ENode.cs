namespace Mon1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class ENode
    {
        [ReadOnly(true)]
        public int id { get; set; }

        [ReadOnly(true)]
        public string composite { get; set; }

        [ReadOnly(true)]
        public string ip { get; set; }

        [ReadOnly(true)]
        public string landscape { get; set; }

        [ReadOnly(true)]
        public string macaddress { get; set; }

        [ReadOnly(true)]
        public string manu { get; set; }

        [ReadOnly(true)]
        public string devicetype { get; set; }

        [ReadOnly(true)]
        public string mhandle { get; set; }

        [ReadOnly(true)]
        public string mname { get; set; }

        [UIHint("Editor"), Required]
        public string notes { get; set; }
    }
}