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
public class YarnManager(ToolboxContext context) : ManagerBase(context, "Yarn")
{
    public static string Version => TerminalUtils.Cmd("yarn -v") ?? string.Empty;

    public static bool IsInstalled
    {
        get
        {
            try
            {
                string? result = TerminalUtils.Cmd("yarn");
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
    /// Run Yarn Updates
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