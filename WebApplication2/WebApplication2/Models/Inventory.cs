using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public Nullable<int> Item_id { get; set; }
        public Nullable<int> Character_id { get; set; }

        public virtual Characters Characters { get; set; }
        public virtual Items Items { get; set; }
    }
}