
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
    
public partial class IFRS9_Transition_Matrix
{

    public string Transition_Matrix_Code { get; set; }

    public string Transition_Matrix_Code_Desc { get; set; }

    public string Current_Rating_Code { get; set; }

    public string Current_Rating_Code_Desc { get; set; }

    public string Next_Rating_Code { get; set; }

    public string Next_Rating_Code_Desc { get; set; }

    public Nullable<double> Migration_Rate { get; set; }

    public Nullable<System.DateTime> Processing_Date { get; set; }

    public string Product_Code { get; set; }

    public string Matrix_Key { get; set; }

    public byte[] Matrix { get; set; }

    public string PRJID { get; set; }

    public string FLOWID { get; set; }

    public string CompID { get; set; }

}

}
