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
    
    public partial class spHRDeleteUserRequestView_Result
    {
        public string DeleteRequestId { get; set; }
        public System.DateTime DeleteRequestDate { get; set; }
        public string JobEmployeeId { get; set; }
        public string NIK { get; set; }
        public string EmployeeName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string DepartementCode { get; set; }
        public string DepartementName { get; set; }
        public string PrivilegeCode { get; set; }
        public string PrivilegeName { get; set; }
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public System.DateTime EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public Nullable<int> Reason { get; set; }
        public string ReasonText { get; set; }
        public string ReasonDesc { get; set; }
        public Nullable<System.DateTime> ResignDate { get; set; }
        public Nullable<System.DateTime> ResignEffectiveDate { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ApprovalDate { get; set; }
        public string ProcessStatus { get; set; }
        public Nullable<System.DateTime> ProcessDate { get; set; }
        public string CancelReason { get; set; }
        public string CreatedBy { get; set; }
    }
}
