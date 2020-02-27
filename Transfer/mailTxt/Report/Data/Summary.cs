using System;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using Transfer.Utility;
using Transfer.ViewModels;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.Models.Repository;
using System.Text.RegularExpressions;

namespace Transfer.Report.Data
{
    public class Summary : ReportData
    {
        public override DataSet GetData(List<reportParm> parms)
        {
            DataSet resultsTable = new DataSet();
            C0Repository c0Repository = new C0Repository();
            D7Repository d7Repository = new D7Repository();

            string sql = string.Empty;
            string ReferenceNbr = parms.Where(x => x.key == "ReferenceNbr").FirstOrDefault()?.value ?? string.Empty;
            string ClassName = parms.Where(x => x.key == "ClassName").FirstOrDefault()?.value ?? string.Empty;
            string ReportDate = parms.Where(x => x.key == "ReportDate").FirstOrDefault()?.value ?? string.Empty;
            string Version = parms.Where(x => x.key == "Version").FirstOrDefault()?.value ?? string.Empty;
            string GroupProductName = parms.Where(x => x.key == "GroupProductName").FirstOrDefault()?.value ?? string.Empty;
            string ProductCode = parms.Where(x => x.key == "ProductCode").FirstOrDefault()?.value ?? string.Empty;

            ReportDate = ReportDate.Replace('/', '-');
            DateTime reportDate = DateTime.Parse(ReportDate);
            string GroupProductCode = Regex.Replace(GroupProductName, "[^0-9]", "");
            GroupProductName = GroupProductName.Split(' ')[0];

            Tuple<bool, List<C07AdvancedSumViewModel>> ECLData = c0Repository.getC07AdvancedSum(ReportDate, Version, GroupProductCode, GroupProductName, ReferenceNbr, "", "", ProductCode);
            Tuple<int, List<SummaryReportInfo>> BTYData = d7Repository.GetSummaryBasicTest(reportDate, "Y");
            Tuple<int, List<SummaryReportInfo>> BTNData = d7Repository.GetSummaryBasicTest(reportDate, "N");
            Tuple<int, List<SummaryReportInfo>> WATData = d7Repository.GetSummaryWatchIND(reportDate, "Y");
            Tuple<int, List<SummaryReportInfo>> WARData = d7Repository.GetSummaryWarningIND(reportDate, "Y");

            DataTable dt = ECLData.Item2.ToDataTable();
            int[] num = { BTYData.Item1, BTNData.Item1, WATData.Item1, WARData.Item1 };
            List<List<SummaryReportInfo>> desc = new List<List<SummaryReportInfo>> { BTYData.Item2, BTNData.Item2, WATData.Item2, WARData.Item2 };
            Tuple<int[], List<List<SummaryReportInfo>>> fieldInfo = new Tuple<int[], List<List<SummaryReportInfo>>>(num, desc);

            XDocument rdlcXml = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "/Report/Rdlc/" + ClassName + ".rdlc");
            XNamespace xmlns = rdlcXml.Root.FirstAttribute.Value;

            int count = 0;
            string lastField = "";
            string firstField = "";

            sql = "SELECT" + "\n";
            for (int i = 0; i < 3; i++)
            {
                firstField = rdlcXml.Descendants(xmlns + "Field").ElementAt(i).FirstAttribute.Value;
                sql += "ISNULL(CONVERT(VARCHAR(MAX),CONVERT(MONEY,'" + dt.Rows[0].Field<string>(firstField) + "'),1),0)AS " + firstField + ",\n";
            }
            sql = sql.Trim().Trim(',') + "\n";

            for (int j = 3; j < rdlcXml.Descendants(xmlns + "Field").Count(); j++)
            {
                lastField = rdlcXml.Descendants(xmlns + "Field").ElementAt(j).FirstAttribute.Value;

                if (j % 2 == 1)
                {
                    firstField = lastField;
                }
                else
                {
                    for (int k = 0; k < fieldInfo.Item2[count].Count; k++)
                    {
                        if (k != 0) { sql += "UNION" + "\n"; }
                        sql += "SELECT" + "\n";
                        sql += "'" + fieldInfo.Item1[count] + "' AS " + firstField + ",\n";
                        sql += "'" + fieldInfo.Item2[count][k].SummaryReportData() + "' AS " + lastField + "\n";
                    }
                    if (!fieldInfo.Item2[count].Any())
                    {
                        sql += "SELECT" + "\n";
                        sql += "'" + fieldInfo.Item1[count] + "' AS " + firstField + ",\n";
                        sql += "'無' AS " + lastField + "\n";
                    }
                    count++;
                }
            }

            using (SqlConnection conn = new SqlConnection(defaultConnection))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    Extension.NlogSet(cmd.CommandText);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(resultsTable);
                }
            }
            return resultsTable;
        }
    }
}