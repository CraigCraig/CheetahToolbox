/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox;

public static partial class GlobalStrings
{
    public static class Registry
    {
        /// <summary>
        /// Run Key - Startup Programs
        /// <br>HKCU</br>
        /// </summary>
        public const string RunKey = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// System Key
        /// <br>HKLM</br>
        /// </summary>
        public const string SystemKey = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";

        /// <summary>
        /// Privacy Key
        /// <br>HKCU</br>
        /// </summary>
        public const string PrivacyKey = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Privacy";

        /// <summary>
        /// Tracks certain stats like how many times you've opened a program
        /// <br>HKCU</br>
        /// </summary>
        public const string CensusKey = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Census";

        /// <summary>
        /// Desktop Settings Key
        /// <br>HKCU</br>
        /// </summary>
        public const string DesktopKey = @"Control Panel\Desktop";

        /// <summary>
        /// Entry for storing the install path and other program settings
        /// <br>HKCU, HKLM</br>
        /// </summary>
        public const string SoftwareKey = @"Software";

        /// <summary>
        /// <br>Windows Metrics Key</br>
        /// <br>HKLM</br>
        /// </summary>
        public const string WindowMetricsKey = @"Control Panel\Desktop\WindowMetrics";

        /// <summary>
        /// <br>Content Delivery Manager Key</br>
        /// <br>HKLM</br>
        /// </summary>
        public const string ContentDeliveryManagerKey = @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";

        /// <summary>
        /// Windows Key
        /// <br>HKCU, HKLM</br>
        /// </summary>
        public const string WindowsKey = @$"Software\Microsoft\Windows\Microsoft\Windows";

        /// <summary>
        /// Current Version Key
        /// </summary>
        public const string CurrentVersionKey = @"Software\Microsoft\Windows\Microsoft\Windows\CurrentVersion";

        /// <summary>
        /// Uninstall Key - Programs and Features Install/Uninstall Programs
        /// </summary>
        public const string UninstallKey = @"Software\Microsoft\Windows\Microsoft\Windows\CurrentVersion\Uninstall";

        /// <summary>
        /// Classes CLSID Key
        /// </summary>
        public const string ClassesCLSIDKey = @"Software\Classes\CLSID";

        /// <summary>
        /// Explorer Key
        /// </summary>
        public const string ExplorerKey = @"Software\Microsoft\Windows\Microsoft\Windows\CurrentVersion\Explorer";

        /// <summary>
        /// Explorer Key
        /// </summary>
        public const string DWMKey = @"Software\Microsoft\Windows\Microsoft\Windows\DWM";

        /// <summary>
        /// Explorer Advanced Key
        /// </summary>
        public const string ExplorerAdvancedKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";

        /// <summary>
        /// Google Chrome Key
        /// <br>HKLM</br>
        /// </summary>
        public const string ChromeKey = @"HKLM\SOFTWARE\Policies\Google\Chrome";

        /// <summary>
        /// Edge Key
        /// <br>HKLM</br>
        /// </summary>
        public const string EdgeKey = @"HKLM\SOFTWARE\Policies\Microsoft\Edge";

        public static class Toolbox
        {
            /// <summary>
            /// Toolbox's <inheritdoc cref="Registry.UninstallKey"/>
            /// </summary>
            public const string UninstallKey = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\CheetahToolbox";

            /// <summary>
            /// Toolbox's <inheritdoc cref="Registry.SoftwareKey"/>
            /// </summary>
            public const string SoftwareKey = @"Software\CheetahToolbox";
        }
    }
}
#endif