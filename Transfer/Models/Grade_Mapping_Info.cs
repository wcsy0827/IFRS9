//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Transfer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grade_Mapping_Info
    {
        public int Id { get; set; }
        public string Rating_Org { get; set; }
        public int PD_Grade { get; set; }
        public string Rating { get; set; }
        public string IsActive { get; set; }
        public string Change_Status { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Processing_Date { get; set; }
        public string Auditor { get; set; }
        public string Status { get; set; }
        public string Auditor_Reply { get; set; }
        public Nullable<System.DateTime> Audit_date { get; set; }
        public string Create_User { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public Nullable<System.TimeSpan> Create_Time { get; set; }
        public string LastUpdate_User { get; set; }
        public Nullable<System.DateTime> LastUpdate_Date { get; set; }
        public Nullable<System.TimeSpan> LastUpdate_Time { get; set; }
    }
}
