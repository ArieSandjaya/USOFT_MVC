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
    
    public partial class spGAPurchaseRequestView_Result
    {
        public string RequestId { get; set; }
        public System.DateTime RequestDate { get; set; }
        public bool IsAsset { get; set; }
        public Nullable<bool> IsTaxPPN { get; set; }
        public decimal TotalPPN { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Reason { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public decimal Total { get; set; }
        public string CurrencyCode { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string DepartementCode { get; set; }
        public string DepartementName { get; set; }
        public string ExistingCondition { get; set; }
        public string Recommendation { get; set; }
        public string Description { get; set; }
        public bool IsStock { get; set; }
        public string Status { get; set; }
        public int ApprovalState { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateName { get; set; }
    }
}
