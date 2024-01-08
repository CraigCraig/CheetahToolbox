/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox.Packages;
public class NpmManager(ToolboxContext context) : ManagerBase(context, "Npm")
{
    public static string Version => TerminalUtils.Cmd("npm -v") ?? string.Empty;

    public static bool IsInstalled
    {
        get
        {
            try
            {
                string? result = TerminalUtils.Cmd("npm");
                return result switch
                {
                    null => false,
                    _ => true
                };
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Run Npm Updates
    /// </summary>
    public void Update()
    {
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Log.Warn("Update Failed: Not running with Administrator privileges.");
            throw new Exceptions.PackageManagerUpdateException();
        }
        string? result = TerminalUtils.Cmd("npm update -g");
        if (result == null)
        {
            Log.Warn("Failed to update Npm");
            return;
        }

        Log.Write(result);
    }
}
#endif