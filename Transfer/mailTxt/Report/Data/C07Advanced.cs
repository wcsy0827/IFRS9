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
    public class C07Advanced : ReportData
    {
        public override DataSet GetData(List<reportParm> parms)
        {
            DataSet resultsTable = new DataSet();
            C0Repository c0Repository = new C0Repository();

            string sql = string.Empty;
            string ClassName = parms.Where(x => x.key == "ClassName").FirstOrDefault()?.value ?? string.Empty;
            string ReportDate = parms.Where(x => x.key == "ReportDate").FirstOrDefault()?.value ?? string.Empty;
            string Version = parms.Where(x => x.key == "Version").FirstOrDefault()?.value ?? string.Empty;
            string GroupProductName = parms.Where(x => x.key == "GroupProductName").FirstOrDefault()?.value ?? string.Empty;
            string ProductCode = parms.Where(x => x.key == "ProductCode").FirstOrDefault()?.value ?? string.Empty;

            ReportDate = ReportDate.Replace('/', '-');
            string GroupProductCode = Regex.Replace(GroupProductName, "[^0-9]", "");

            Tuple<string, List<C07AdvancedViewModel>> queryData = c0Repository.getC07Advanced(GroupProductCode, ProductCode, ReportDate, Version, "", "");

            DataTable dt = queryData.Item2.ToDataTable();

            XDocument rdlcXml = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "/Report/Rdlc/" + ClassName + ".rdlc");
            XNamespace xmlns = rdlcXml.Root.FirstAttribute.Value;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i != 0) { sql += "UNION ALL" + "\n"; }
                sql += "SELECT" + "\n";
                foreach (XElement element in rdlcXml.Descendants(xmlns + "Field"))
                {
                    string Field = element.FirstAttribute.Value;
                    sql += "'" + dt.Rows[i].Field<string>(Field) + "' AS " + Field + ",\n";
                }
                sql = sql.Trim().Trim(',') + "\n";
            }
            if (dt.Rows.Count == 0)
            {
                sql += "SELECT" + "\n";
                foreach (XElement element in rdlcXml.Descendants(xmlns + "Field"))
                {
                    string Field = element.FirstAttribute.Value;
                    sql += "'' AS " + Field + ",\n";
                }
            }
            sql = sql.Trim().Trim(',');

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