/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox.Registry;

public static class RegistryLocations
{
    // WIP: Add other locations
    public static readonly RegistryLocation Software = new(GlobalStrings.Registry.Toolbox.SoftwareKey, string.Empty);
    public static readonly RegistryLocation InstallPath = new(GlobalStrings.Registry.Toolbox.SoftwareKey, "InstallPath");
    public static readonly RegistryLocation Uninstall = new(GlobalStrings.Registry.Toolbox.UninstallKey, string.Empty);
    public static readonly RegistryLocation UninstallName = new(GlobalStrings.Registry.Toolbox.UninstallKey, "DisplayName");

    public static class Desktop
    {
        public static readonly RegistryLocation PaintDesktopVersion = new(GlobalStrings.Registry.DesktopKey, "PaintDesktopVersion");
        public static readonly RegistryLocation MenuShowDelay = new(GlobalStrings.Registry.DesktopKey, "MenuShowDelay");
    }

    public static class Explorer
    {
        public static readonly RegistryLocation ShowRecommendations = new(GlobalStrings.Registry.ExplorerKey, "ShowRecommendations");
        public static readonly RegistryLocation ShowCloudFilesInQuickAccess = new(GlobalStrings.Registry.ExplorerKey, "ShowCloudFilesInQuickAccess");

        public static class Advanced
        {
            public static readonly RegistryLocation ShowHiddenFiles = new(GlobalStrings.Registry.ExplorerAdvancedKey, "Hidden");
            public static readonly RegistryLocation HideFileExtensions = new(GlobalStrings.Registry.ExplorerAdvancedKey, "HideFileExt");
            public static readonly RegistryLocation ShowCopilotButton = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowCopilotButton");
            public static readonly RegistryLocation ShowSystemFiles = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowSuperHidden");
            public static readonly RegistryLocation SeparateProcess = new(GlobalStrings.Registry.ExplorerAdvancedKey, "SeparateProcess");
            public static readonly RegistryLocation ShowInfoTip = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowInfoTip");
            public static readonly RegistryLocation ShowCompColor = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowCompColor");
            public static readonly RegistryLocation ShowEncryptCompressedColor = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowEncryptCompressedColor");
            public static readonly RegistryLocation TaskbarAnimations = new(GlobalStrings.Registry.ExplorerAdvancedKey, "TaskbarAnimations");
        }

        /// <summary>
        /// Doesn't automatically search for network folders and printers.
        /// </summary>
        public static readonly RegistryLocation NoNetCrawling = new(GlobalStrings.Registry.ExplorerAdvancedKey, "NoNetCrawling");
    }

    public static class DWM
    {

    }

    /// <summary>
    /// Google Chrome
    /// </summary>
    public static class Chrome
    {
        public static readonly RegistryLocation MetricsReportingEnabled = new(GlobalStrings.Registry.ChromeKey, "MetricsReportingEnabled");
        public static readonly RegistryLocation ChromeCleanupReportingEnabled = new(GlobalStrings.Registry.ChromeKey, "ChromeCleanupReportingEnabled");
        public static readonly RegistryLocation ChromeCleanupEnabled = new(GlobalStrings.Registry.ChromeKey, "ChromeCleanupEnabled");
    }

    /// <summary>
    /// Edge
    /// </summary>
    public static class Edge
    {
        /// <summary>
        /// Giant Bing search (AI chat) button in Edge Browser
        /// </summary>
        public static readonly RegistryLocation HubsSidebarEnabled = new(GlobalStrings.Registry.EdgeKey, "HubsSidebarEnabled");
    }

    /// <summary>
    /// Items in this category do not have their own yet.
    /// </summary>
    public static class Misc
    {
        //  \Control Panel\Desktop\WindowMetrics
        public static readonly RegistryLocation MinAnimate = new(GlobalStrings.Registry.WindowMetricsKey, "MinAnimate");

        public static readonly RegistryLocation SilentInstalledAppsEnabled = new(GlobalStrings.Registry.ContentDeliveryManagerKey, "SilentInstalledAppsEnabled");
        public static readonly RegistryLocation TailoredExperiencesWithDiagnosticDataEnabled = new(GlobalStrings.Registry.PrivacyKey, "TailoredExperiencesWithDiagnosticDataEnabled");

        /// <summary>
        /// Suggested content in Settings app.
        /// </summary>
        public static readonly RegistryLocation SubscribedContent338393Enabled = new(GlobalStrings.Registry.ContentDeliveryManagerKey, "SubscribedContent338393Enabled");

        /// <summary>
        /// Suggested content in Settings app.
        /// </summary>
        public static readonly RegistryLocation SubscribedContent353694Enabled = new(GlobalStrings.Registry.ContentDeliveryManagerKey, "SubscribedContent353694Enabled");

        /// <summary>
        /// Suggested content in Settings app.
        /// </summary>
        public static readonly RegistryLocation SubscribedContent353696Enabled = new(GlobalStrings.Registry.ContentDeliveryManagerKey, "SubscribedContent353696Enabled");

        public static readonly RegistryLocation VerboseStatus = new(GlobalStrings.Registry.SystemKey, "verbosestatus");
    }
}
#endif