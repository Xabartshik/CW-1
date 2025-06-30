namespace EShop.Application.Settings
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";

        public string ApplicationName { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public int MaxProductsPerPage { get; set; } = 10;
        public bool EnableDetailedLogging { get; set; } = false;
    }
}