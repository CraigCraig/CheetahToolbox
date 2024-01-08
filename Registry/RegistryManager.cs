/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
/// Windows Registry Information
/// https://renenyffenegger.ch/notes/Windows/registry/
#if WINDOWS
namespace CheetahToolbox.Registry;

#region Using Statements
using Microsoft.Win32;
#endregion

/// <summary>
/// Registry Manager
/// </summary>
public class RegistryManager : ManagerBase
{
    private readonly List<string> CLSID = [];

    public RegistryManager(ToolboxContext context) : base(context, "Registry")
    {
#if DEBUG && VERBOSE
        // TODO: Move to commands

        //Log.Write($"Paint Desktop Version: {RegistryLocations.Desktop.PaintDesktopVersion.GetBool()}");
        //Log.Write($"Show Menu Delay: {RegistryLocations.Desktop.MenuShowDelay.GetInt()}");

        //Log.Write($"Show Copilot Button: {RegistryLocations.Explorer.Advanced.ShowCopilotButton.GetBool()}");
        //Log.Write($"Show Hidden Files: {RegistryLocations.Explorer.Advanced.ShowHiddenFiles.GetBool()}");
        //Log.Write($"Show System Files: {RegistryLocations.Explorer.Advanced.ShowSystemFiles.GetBool()}");
        //Log.Write($"Verbose Status: {RegistryLocations.Misc.VerboseStatus.GetInt()}");
#endif

        // Scan Root Key
        RegistryKey? root = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID");

        if (root != null)
        {
            string[]? keys = root.GetSubKeyNames();

            foreach (string key in keys)
            {
                RegistryKey? skey = root.OpenSubKey(key);
                if (skey?.GetValue(string.Empty) is string value)
                    CLSID.Add(key);
            }
            Log.Write($"[RegistryManager] Cached: {CLSID.Count} CSLID");
        }

        //string installPath = RegistryUtils.GetString(RegistryTarget.HKCU, RegistryLocations.InstallPath) ?? string.Empty;
        //Log.Write($"Registry InstallPath: {installPath}");

        // Test Setting InstallPath
        //RegistryUtils.SetString(RegistryTarget.HKCU, RegistryLocations.InstallPath, "test");

        return;
        ////Log.Write("Registry Manager Initializing..");
        //Stopwatch sw = Stopwatch.StartNew();

        //// Census
        //RegistryKey? census = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Census");
        //if (census != null)
        //{
        //    if (census?.GetValue("StartTimeBin") is long startTimeBin)
        //    {
        //        string startTime = new DateTime(startTimeBin).ToString();
        //    }
        //}

        //// Privacy
        //RegistryKey? privacy = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Privacy");
        //if (privacy != null)
        //{
        //    if (privacy?.GetValue("TailoredExperiencesWithDiagnosticDataEnabled") is int tailoredExperiencesWithDiagnosticDataEnabled)
        //    {
        //        if (tailoredExperiencesWithDiagnosticDataEnabled == 1)
        //            tailoredExperiencesWithDiagnosticDataEnabled = 0;
        //    }
        //}

        //// Desktop Settings
        //RegistryKey? desktop = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop");
        //if (desktop != null)
        //{
        //    string[] values = desktop.GetValueNames();
        //    foreach (string value in values)
        //    {
        //        //Log.Write($"{value}");

        //        if (desktop.GetValue(value) is string data)
        //        {
        //            //Log.Write($"{data}");
        //        }

        //        if (desktop.GetValue(value) is int data2)
        //        {
        //            //Log.Write($"{data2}");
        //        }
        //    }
        //}

        //if (RegistryTweaker.PaintDesktopVersion)
        //{
        //    //Log.Write("PaintDesktopVersion is Enabled");
        //}

        //// Check Advertising Info
        //if (RegistryTweaker.AdvertisingInfo)
        //{
        //    //Log.Write("AdvertisingInfo is Enabled");
        //}

        ////Log.Write("================");
        //// Check Startup
        //RegistryKey? startupKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
        //if (startupKey != null)
        //{
        //    //Log.Write(startupKey.Name);
        //    foreach (string valueName in startupKey.GetValueNames())
        //    {
        //        //Log.Write($"{valueName} -> {startupKey.GetValue(valueName)}");
        //    }
        //}

        ////Log.Write("================");
        //// Uninstall Entries
        //List<RegistryKey> toCheck = [];
        //toCheck.Add(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ?? throw new UnknownKeyException());
        //toCheck.Add(Registry.CurrentUser.OpenSubKey(@"Software\\Microsoft\Windows\CurrentVersion\Uninstall") ?? throw new UnknownKeyException());

        //foreach (RegistryKey root2 in toCheck)
        //{
        //    foreach (string subKeyName in root2.GetSubKeyNames())
        //    {
        //        RegistryKey? subKey = root2.OpenSubKey(subKeyName);
        //        if (subKey != null)
        //        {
        //            string? displayName = subKey.GetValue("DisplayName")?.ToString();

        //            if (string.IsNullOrEmpty(displayName))
        //                //Log.Write($"Name for {subKey.Name} was NULL, using Key name");
        //                displayName = subKey.Name;

        //            string? displayIcon = subKey.GetValue("DisplayIcon")?.ToString();
        //            if (string.IsNullOrEmpty(displayIcon))
        //            {
        //                //Log.Write($"DisplayIcon not set for {displayName}");
        //            }

        //            string? installLocation = subKey.GetValue("InstallLocation")?.ToString();
        //            if (string.IsNullOrEmpty(installLocation))
        //            {
        //                //Log.Write($"InstallLocation not set for {displayName}");
        //            }
        //            else
        //            {
        //                if (!Directory.Exists(installLocation) && !File.Exists(installLocation))
        //                {
        //                    //Log.Write($"Invalid Install Path: {installLocation}");
        //                }
        //            }
        //        }
        //    }
        //}

        //sw.Stop();
    }

    private bool CheckUninstallEntry(RegistryKey subKey)
    {
        bool result = false;
        string? displayName = subKey.GetValue("DisplayName")?.ToString();
        string? displayIcon = subKey.GetValue("DisplayIcon")?.ToString()?.Split(',')[0];
        string? installLocation = subKey.GetValue("InstallLocation")?.ToString();
        // string? uninstallString = subKey.GetValue("UninstallString")?.ToString();

        if (!string.IsNullOrEmpty(displayIcon) && !File.Exists(displayIcon))
            result = true;

        if (!string.IsNullOrEmpty(installLocation))
        {
            if (!Directory.Exists(installLocation))
                result = true;
        }

        if (result && !string.IsNullOrEmpty(displayName)) Log.Write($"{displayName} - is a ghost app");

        return result;
    }

    /// <summary>
    /// Apply/Revert Registry to Defaults
    /// </summary>
    public static void ApplyDefaults()
    {
        // TODO: Implement Apply Defaults

        // RegistryLocations.Desktop.PaintDesktopVersion.Reset();
    }

    /// <summary>
    /// Apply Recommended Registry Tweaks
    /// </summary>
    public static void ApplyRecommended()
    {
        // TODO: Implement Apply Recommended

        //RegistryLocations.Desktop.PaintDesktopVersion.Bool = false;
        // Telemetry.AdvertisingInfo = false;
    }
}
#endif