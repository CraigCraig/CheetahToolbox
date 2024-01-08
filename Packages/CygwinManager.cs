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
public class CygwinManager(ToolboxContext context) : ManagerBase(context, "Cygwin")
{
    public static string Version => TerminalUtils.Cmd("cygwin -v") ?? string.Empty;

    public static bool IsInstalled
    {
        get
        {
            try
            {
                string? result = TerminalUtils.Cmd("cygwin");
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
    }
}
#endif