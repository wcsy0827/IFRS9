using System.Collections.Generic;

namespace Transfer.Utility
{
    public class GetQueryValue
    {
    }

    public class VersionInfo
    {
        public string Version { get; set; }
        public string VersionContent { get; set; }
        public string VersionData()
        {
            return Version + "_" + VersionContent;
        }
    }

    public class StatusInfo
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string StatusData()
        {
            return Status + "_" + Description;
        }
    }

    public class GroupProduct
    {
        public string GroupProductName { get; set; }
        public string GroupProductCode { get; set; }
        public IEnumerable<string> ProductCode { get; set; }
        public string ProductData()
        {
            string productCode = string.Join(",", ProductCode);
            return productCode + "|" + GroupProductName + " (" + GroupProductCode + ")";
        }
    }

    public class BondBasicAssessment
    {
        public string RuleID { get; set; }
        public string RuleDesc { get; set; }
        public string NumberPen { get; set; }
        public string BondBasicAssessmentData()
        {
            if (RuleDesc == null) { RuleDesc = "無說明"; }
            return "規則編號:" + RuleID + "(" + RuleDesc + "):" + NumberPen + "筆";
        }
    }
}