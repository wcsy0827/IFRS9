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
    
    public partial class Risk_Parm
    {
        public int Rule_ID { get; set; }
        public string Bond_Type { get; set; }
        public string Rating_Floor { get; set; }
        public string Including_Ind { get; set; }
        public string Apply_Range { get; set; }
        public string Data_Year { get; set; }
        public int PD_Grade { get; set; }
        public int Grade_Adjust { get; set; }
        public string Rule_setter { get; set; }
        public System.DateTime Rule_setting_Date { get; set; }
        public string Auditor { get; set; }
        public Nullable<System.DateTime> Audit_Date { get; set; }
        public string Status { get; set; }
        public string Rule_desc { get; set; }
        public string IsActive { get; set; }
    }
}
