
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
    
public partial class Loan_Account_Info
{

    public string Reference_Nbr { get; set; }

    public string Seg_Name { get; set; }

    public int Delinquent_Days { get; set; }

    public string Current_Rating_Code { get; set; }

    public Nullable<double> Org_Amt { get; set; }

    public double Current_Int_Rate { get; set; }

    public string Mtr_Date { get; set; }

    public string Exp_Date { get; set; }

    public Nullable<double> Cur_Int { get; set; }

    public string Lorg_Date { get; set; }

    public string Lexp_Date { get; set; }

    public string Cf_Type { get; set; }

    public string PAY_FRQ { get; set; }

    public Nullable<int> Init_Days { get; set; }

    public string Int_Type { get; set; }

    public string Obj_Impair { get; set; }

    public string Mdr_Month { get; set; }

    public Nullable<double> Org_Pd { get; set; }

    public Nullable<double> Org_Efint { get; set; }

    public string Currency { get; set; }

    public double Current_LGD { get; set; }

    public Nullable<double> Unpaid_Bal { get; set; }

    public string Nxt_Int_Dt { get; set; }

    public Nullable<double> Nxt_Int_Rt { get; set; }

    public Nullable<int> Tot_Trms { get; set; }

    public Nullable<int> Left_Trms { get; set; }

    public Nullable<System.DateTime> Processing_Date { get; set; }

    public System.DateTime Report_Date { get; set; }

    public string Rating_Date { get; set; }

    public string Restructure_Ind { get; set; }

    public string Collateral_Legal_Action_Ind { get; set; }

    public string Bad_Debt_Ind { get; set; }

    public string Collection_Ind { get; set; }

}

}
