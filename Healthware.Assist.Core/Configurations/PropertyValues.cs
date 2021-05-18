namespace Healthware.Assist.Core.Configurations
{
     public static class PropertyValues
    {
        private static string CanEnableMockData{ get; set; }
        private static string EDRMBaseUrl { get; set; }
        private static string AdminEmail { get; set; }
        private static string EnvironmentName { get; set; }

        public static void EnableMockData(string value)
        {
            PropertyValues.CanEnableMockData = value;
        }

        public static bool isMockEnabled()
        {
            return PropertyValues.CanEnableMockData.ToLower().Equals("true");
        }
        public static void SetEDRMBaseUrl(string value)
        {
            PropertyValues.EDRMBaseUrl = value;
        }
        public static string GetEDRMBaseUrl()
        {
            return PropertyValues.EDRMBaseUrl;
        }

        public static void SetAdminEmail(string value)
        {
            PropertyValues.AdminEmail = value;
        }
        public static string GetAdminEmail()
        {
            return PropertyValues.AdminEmail;
        }
        public static void SetEnvironmentName(string value)
        {
            PropertyValues.EnvironmentName = value;
        }
        public static string GetEnvironmentName()
        {
            return PropertyValues.EnvironmentName;
        }
    }
}
