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
            D6Repository d6Repository = new D6Repository();

            string sql = string.Empty;
            string className = parms.Where(x => x.key == "ClassName").FirstOrDefault()?.value ?? string.Empty;
            string reportDate = parms.Where(x => x.key == "ReportDate").FirstOrDefault()?.value ?? string.Empty;
            string version = parms.Where(x => x.key == "Version").FirstOrDefault()?.value ?? string.Empty;
            string groupProductCode = parms.Where(x => x.key == "GroupProductCode").FirstOrDefault()?.value ?? string.Empty;
            string groupProductName = groupProductCode.Split(' ')[0];
            string productCode = parms.Where(x => x.key == "ProductCode").FirstOrDefault()?.value ?? string.Empty;

            reportDate = reportDate.Replace('/', '-');
            DateTime _reportDate = DateTime.Parse(reportDate);
            groupProductCode = Regex.Replace(groupProductCode, "[^0-9]", "");

            Tuple<bool, List<C07AdvancedSumViewModel>> ECLData = c0Repository.getC07AdvancedSum(reportDate, version, groupProductCode, groupProductName, "All", "", "", productCode);
            Tuple<int, List<BondBasicAssessment>> BTYCData = d6Repository.getSummaryBasicTest(_reportDate, "Y");
            Tuple<int, List<BondBasicAssessment>> BTNCData = d6Repository.getSummaryBasicTest(_reportDate, "N");
            Tuple<int, List<BondBasicAssessment>> WIYCData = d6Repository.getSummaryWatchIND(_reportDate, "Y");
            Tuple<int, List<BondBasicAssessment>> WIIYCData = d6Repository.getSummaryWarningIND(_reportDate, "Y");

            DataTable dt = ECLData.Item2.ToDataTable();
            int[] num = { BTYCData.Item1, BTNCData.Item1, WIYCData.Item1, WIIYCData.Item1 };
            List<List<BondBasicAssessment>> desc = new List<List<BondBasicAssessment>> { BTYCData.Item2, BTNCData.Item2, WIYCData.Item2, WIIYCData.Item2 };
            Tuple<int[], List<List<BondBasicAssessment>>> fieldInfo = new Tuple<int[], List<List<BondBasicAssessment>>>(num, desc);

            XDocument rdlcXml = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "/Report/Rdlc/" + className + ".rdlc");
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
                        sql += "'" + fieldInfo.Item2[count][k].BondBasicAssessmentData() + "' AS " + lastField + "\n";
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