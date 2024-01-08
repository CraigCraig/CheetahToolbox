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
public class WingetManager(ToolboxContext context) : ManagerBase(context, "Winget")
{
    public static string Version => TerminalUtils.Cmd("winget -v") ?? string.Empty;

    public static bool IsInstalled
    {
        get
        {
            try
            {
                string? result = TerminalUtils.Cmd("winget");
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
    /// Run Winget Updates
    /// </summary>
    public void Update()
    {
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Log.Warn("Update Failed: Not running with Administrator privileges.");
            throw new Exceptions.PackageManagerUpdateException();
        }
        string? result = TerminalUtils.Cmd("winget upgrade --all --disable-interactivity");
        if (result == null)
        {
            Log.Warn("Failed to update Winget");
            return;
        }

        Log.Write(result);
    }
}
#endif