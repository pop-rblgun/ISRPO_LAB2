//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public int ID { get; set; }
        public Nullable<int> Item_id { get; set; }
        public Nullable<int> Character_id { get; set; }
    
        public virtual Characters Characters { get; set; }
        public virtual Items Items { get; set; }
    }
}