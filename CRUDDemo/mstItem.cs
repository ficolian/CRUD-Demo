//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class mstItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
