
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
    
public partial class IFRS9_Log
{

    public int Id { get; set; }

    public string Table_type { get; set; }

    public string Table_name { get; set; }

    public string File_name { get; set; }

    public string Program_name { get; set; }

    public string Create_date { get; set; }

    public string Create_time { get; set; }

    public string End_date { get; set; }

    public string End_time { get; set; }

    public string TYPE { get; set; }

    public string Debt_Type { get; set; }

    public Nullable<int> Version { get; set; }

    public string User_Account { get; set; }

    public Nullable<System.DateTime> Report_Date { get; set; }

}

}
