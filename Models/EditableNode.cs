using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mon1.Models
{
    public class EditableNode: Node
    {
        [UIHint("Editor"), Required]
        new public string notes { get; set; }
    }
}