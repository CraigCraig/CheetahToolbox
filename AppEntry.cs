/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;

public class AppEntry(string? name, string? version, string? clsid, string? installPath, AppEntry.AppSource source)
{
    public string? Name = name;
    public string? Version = version; // TODO: Compare AppEntry Versions
    public string? CLSID = clsid;
    public string? InstallPath = installPath;
    public AppSource Source = source;

#if WINDOWS
    public enum AppSource
    {
        LOCAL, CHOCOLATEY, WINGET, SCOOP
    }
#else
    public enum AppSource
    {
        LOCAL
    }
#endif
}