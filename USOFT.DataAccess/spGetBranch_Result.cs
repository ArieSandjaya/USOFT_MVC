//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USOFT.DataAccess
{
    using System;
    
    public partial class spGetBranch_Result
    {
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int BranchType { get; set; }
        public Nullable<int> BranchParent { get; set; }
        public string BranchAddress { get; set; }
        public string BranchPhone { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public string update_by { get; set; }
    }
}
