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
public class ScoopManager(ToolboxContext context) : ManagerBase(context, "Scoop")
{
    public static string Version
    {
        get
        {
            string? result = TerminalUtils.Cmd("scoop -v") ?? string.Empty;
            string[] split = result.Replace("\r", "").Split("\n");
            string line = split[1].Replace("\n", "").Trim();
            string[] split2 = line.Split(' ');
            return split2[0].Replace("\n", "").Trim();
        }
    }

    public static bool IsInstalled
    {
        get
        {
            try
            {
                string? result = TerminalUtils.Cmd("scoop");
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
    /// Run Scoop Updates
    /// </summary>
    public void Update()
    {
        // WIP: https://github.com/ScoopInstaller/Scoop/issues/3954
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Log.Warn("Update Failed: Not running with Administrator privileges.");
            throw new Exceptions.PackageManagerUpdateException();
        }
        string? result = TerminalUtils.PowerShell("scoop update");
        if (result == null)
        {
            Log.Warn("Failed to update Scoop");
            return;
        }

        Log.Write(result);
    }
}
#endif