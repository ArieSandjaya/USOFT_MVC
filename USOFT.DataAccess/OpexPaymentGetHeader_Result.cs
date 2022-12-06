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
    
    public partial class OpexPaymentGetHeader_Result
    {
        public string OPEX_PAYMENT_NO { get; set; }
        public string DOCUMENT_TYPE { get; set; }
        public string OPEX_TYPE { get; set; }
        public Nullable<int> BRANCH_ID { get; set; }
        public string DEPARTEMENTCODE { get; set; }
        public Nullable<int> SBP_CODE { get; set; }
        public string INVOICE_NUMBER { get; set; }
        public string DESCRIPTION { get; set; }
        public string RECEPIENT_NAME { get; set; }
        public string RECEPIENT_NPWP { get; set; }
        public string RECEPIENT_ADDRESS { get; set; }
        public string RECEPIENT_ID_NUMBER { get; set; }
        public string RECEPIENT_PKP { get; set; }
        public string RECEPIENT_WHTAX { get; set; }
        public string RECEPIENT_BANK_TYPE { get; set; }
        public string BENEFICIARY_BANK { get; set; }
        public string RECEPIENT_ACC_NUMBER { get; set; }
        public string RECEPIENT_ACC_NAME { get; set; }
        public string CCY { get; set; }
        public Nullable<decimal> TOTAL_DPP { get; set; }
        public Nullable<decimal> TOTAL_VAT { get; set; }
        public Nullable<decimal> TOTAL_WH_TAX { get; set; }
        public Nullable<decimal> TOTAL_STAMP_DUTY { get; set; }
        public Nullable<decimal> TOTAL_BIAYA_LAIN { get; set; }
        public decimal TOTAL_AMOUNT_PAID { get; set; }
        public string APPROVAL_STATUS { get; set; }
        public string WORKFLOW_CODE { get; set; }
        public string ACTIVE { get; set; }
        public int CREATED_BRANCH { get; set; }
        public string CREATED_DEPT { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public short RECIPIENT_TYPE { get; set; }
    }
}