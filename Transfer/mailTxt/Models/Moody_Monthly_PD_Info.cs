
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
    
public partial class Moody_Monthly_PD_Info
{

    public int Id { get; set; }

    public Nullable<System.DateTime> Trailing_12m_Ending { get; set; }

    public Nullable<double> Actual_Allcorp { get; set; }

    public Nullable<double> Baseline_forecast_Allcorp { get; set; }

    public Nullable<double> Pessimistic_Forecast_Allcorp { get; set; }

    public Nullable<double> Actual_SG { get; set; }

    public Nullable<double> Baseline_forecast_SG { get; set; }

    public Nullable<double> Pessimistic_Forecast_SG { get; set; }

    public string Data_Year { get; set; }

}

}