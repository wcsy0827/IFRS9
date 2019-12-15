using System.Data;
using Transfer.Utility;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Transfer.Report.Data
{
    public class Summary : ReportData
    {
        public override DataSet GetData(List<reportParm> parms)
        {
            DataSet resultsTable = new DataSet();
            using (SqlConnection conn = new SqlConnection(defaultConnection))
            {
                string sql = string.Empty;
                DateTime reportDate = DateTime.Parse(parms[0].value);
                string _reportDate = reportDate.ToString("yyyy-MM-dd");
                string version = parms[1].value;
                
                //Joe:結果輸出
                sql +=string.Format(
                    @"
                    DECLARE @REPORT_DATE DATE = '{0}', @VERSION INT = '{1}';
                    
                    SELECT
                    (
                    ---C07或是C07Advanced中'一年期預期信用損失(台幣)'加總
                    SELECT ISNULL(CONVERT(VARCHAR(MAX),CONVERT(MONEY,SUM([Y1_EL])),1),0)
                    FROM [IFRS9].[DBO].[EL_DATA_OUT]
                    WHERE REPORT_DATE = @REPORT_DATE AND VERSION = @VERSION) AS OneYECL,
                    (
                    ---C07或是C07Advanced中'存續期間預期信用損失(台幣)'加總
                    SELECT ISNULL(CONVERT(VARCHAR(MAX),CONVERT(MONEY,SUM([Lifetime_EL])),1),0)
                    FROM [IFRS9].[DBO].[EL_DATA_OUT]
                    WHERE REPORT_DATE = @REPORT_DATE AND VERSION = @VERSION) AS LifetimeECL,
                    (
                    ---C07或是C07Advanced中'曝險額(台幣)'加總
                    SELECT 0.0) AS Balance;

                    SELECT
                    (
                    ---筆數統計:可參考D62報表之S欄(對應D69-基本要件參數檔規則編號)
                    SELECT 0.0) AS PassNumber,
                    (
                    SELECT 0.0) AS FailNumber,
                    (
                    ---規則敘述:可參考D69參數檔Rule_desc
                    SELECT 0.0) AS PassDescription,
                    (
                    SELECT 0.0) AS FailDescription;

                    SELECT
                    (
                    ---筆數統計:可參考D62報表之AG欄(對應D71-預警名單參數檔規則編號)
                    SELECT 0.0) AS WarnNumber,
                    (
                    SELECT 0.0) AS WatchNumber,
                    (
                    ---規則敘述:可參考D71參數檔Rule_desc
                    SELECT 0.0) AS WarnDescription,
                    (
                    SELECT 0.0) AS WatchDescription;

                    ", _reportDate,version);

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(resultsTable);
                }
            }
            return resultsTable;
        }
    }
}