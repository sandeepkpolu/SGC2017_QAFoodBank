//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QAFoodBank.MobileAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemSource
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int VendorId { get; set; }
        public string URL { get; set; }
    
        public virtual ItemSource ItemSource1 { get; set; }
        public virtual ItemSource ItemSource2 { get; set; }
        public virtual ItemVendor ItemVendor { get; set; }
    }
}
