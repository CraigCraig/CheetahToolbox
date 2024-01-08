/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;

public static class FolderPaths
{
    public static string RoamAppData => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CheetahToolbox");
    public static string LocalAppData => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CheetahToolbox");
    public static string ProgramFiles => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "CheetahToolbox");
    public static string Modules => Path.Combine(Environment.CurrentDirectory, "Modules");
}