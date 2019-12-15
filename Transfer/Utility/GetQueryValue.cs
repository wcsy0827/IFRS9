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
        public string ProductData()
        {
            return GroupProductName + " (" + GroupProductCode + ")";
        }
    }
}