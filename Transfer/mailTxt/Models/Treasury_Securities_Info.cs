
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
    
public partial class Treasury_Securities_Info
{

    public string Bond_Number { get; set; }

    public string Lots { get; set; }

    public string Segment_Name { get; set; }

    public string Portfolio_Name { get; set; }

    public double Bond_Value { get; set; }

    public double Ori_Amount { get; set; }

    public double Principal { get; set; }

    public double Amort_value { get; set; }

    public System.DateTime Processing_Date { get; set; }

    public System.DateTime Report_Date { get; set; }

    public string Security_Name { get; set; }

}

}