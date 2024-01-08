/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;
/// <summary>
/// Contains information about the current environment.
/// </summary>
public class EnvironmentManager : ManagerBase
{
    public string UserName = Environment.UserName;
    public string MachineName = Environment.MachineName;
    public string MachineVersion = Environment.OSVersion.VersionString;
    public string Path = Environment.GetEnvironmentVariable("Path") ?? string.Empty;
    public string CurrentDirectory = Environment.CurrentDirectory;

    public EnvironmentManager(ToolboxContext context) : base(context, "Environment")
    {
        Log.Write($"UserName: {UserName}");
        Log.Write($"MachineName: {MachineName}");
        Log.Write($"MachineVersion: {MachineVersion}");
        //Log.Write($"Path: {Path}");
        Log.Write($"CurrentDirectory: {CurrentDirectory}");
    }

    //Log.Write("Cheetah Environment Starting");
    //Log.Write("Settings Environment Variables");
    //Log.Write("==============================");
    //Log.Write($"UserName: {UserName}");
    //Log.Write($"MachineName: {MachineName}");
    //Log.Write($"MachineVersion: {MachineVersion}");
    //Log.Write("===============================");
    //Log.Write("Setting Paths");
    //Path = Environment.GetEnvironmentVariable("PATH") ?? "";
    //RegistryKey? key = Registry.CurrentUser.OpenSubKey(GlobalStrings.InstallPath);
    //Log.Write(key);
    //if (key == null)
    //{
    //    key = Registry.CurrentUser.CreateSubKey(GlobalStrings.InstallPath);
    //    Log.Write(key);
    //    if (key == null)
    //    {
    //        Log.Write("Error: Unable to create registry key");
    //        return;
    //    }
    //    key.SetValue("InstallPath", InstallPath);
    //    return;
    //}
    //else
    //{
    //    Log.Write("Key Found");
    //}
}
