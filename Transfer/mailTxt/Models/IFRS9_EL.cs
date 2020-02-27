
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
    
public partial class IFRS9_EL
{

    public string PRJID { get; set; }

    public string FLOWID { get; set; }

    public string Report_Date { get; set; }

    public int Version { get; set; }

    public string Processing_Date { get; set; }

    public string Product_Code { get; set; }

    public string Reference_Nbr { get; set; }

    public string Bond_Number { get; set; }

    public string Lots { get; set; }

    public string Portfolio_Name { get; set; }

    public string Segment_Name { get; set; }

    public string Impairment_Stage { get; set; }

    public Nullable<double> PD { get; set; }

    public Nullable<double> Lifetime_EL { get; set; }

    public Nullable<double> Y1_EL { get; set; }

    public Nullable<double> EL { get; set; }

    public Nullable<double> Ex_rate { get; set; }

    public Nullable<double> Ori_Ex_rate { get; set; }

    public Nullable<double> Lifetime_EL_Ex { get; set; }

    public Nullable<double> Y1_EL_Ex { get; set; }

    public Nullable<double> EL_Ex { get; set; }

    public Nullable<double> Lifetime_EL_Ori_Ex { get; set; }

    public Nullable<double> Y1_EL_Ori_Ex { get; set; }

    public Nullable<double> EL_Ori_Ex { get; set; }

    public Nullable<System.DateTime> Exec_Date { get; set; }

    public string Create_User { get; set; }

    public Nullable<System.DateTime> Create_Date { get; set; }

    public Nullable<System.TimeSpan> Create_Time { get; set; }

    public string LastUpdate_User { get; set; }

    public Nullable<System.DateTime> LastUpdate_Date { get; set; }

    public Nullable<System.TimeSpan> LastUpdate_Time { get; set; }

    public Nullable<double> PD_Int { get; set; }

    public Nullable<double> Ori_Ex_rate_to_USD { get; set; }

    public Nullable<double> Ex_rate_to_USD { get; set; }

    public string Trading_Number { get; set; }

}

}
