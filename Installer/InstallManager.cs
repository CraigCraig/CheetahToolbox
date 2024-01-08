/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox.Installer;

using Microsoft.Win32;

public class InstallManager(ToolboxContext context) : ManagerBase(context, "Installer")
{
    public static bool IsInstalled
    {
        get
        {
            try
            {
                return Environment.CurrentDirectory.Equals(FolderPaths.ProgramFiles, StringComparison.Ordinal);
            }
            catch { }
            return false;
        }
    }

    public void Execute()
    {
        Log.Write("Installing CheetahTerminal..");
        RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CheetahTerminal");
        if (key == null)
        {
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CheetahTerminal");
            if (key != null)
            {
                //Log.Write($"Key Found: {key}");
            }
            else
            {
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CheetahTerminal");
                //Log.Write($"Key Created: {key}");
            }

            string? value = key.GetValue(key.Name) as string;

            if (!string.IsNullOrEmpty(value))
            {
                Log.Write($"Found: {value}");
                key.SetValue("InstallPath", FolderPaths.ProgramFiles);
            }
            //Log.Write($"Found: {value}");
            //key.SetValue("InstallPath", FolderPaths.ProgramFiles);
            //Log.Write($"Registry Entry: {key}");
        }

        //key.SetValue("InstallPath", FolderPaths.ProgramFiles);

        //RegistryKey uninstallKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\CheetahTerminal");
        //uninstallKey.SetValue("DisplayName", "CheetahTerminal");

        //string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine) ?? string.Empty;
        //if (path != null && !path.Contains(FolderPaths.ProgramFiles))
        //    Environment.SetEnvironmentVariable("Path", path + ";" + FolderPaths.ProgramFiles, EnvironmentVariableTarget.Machine);

        //if (!Directory.Exists(FolderPaths.LocalAppData))
        //    _ = Directory.CreateDirectory(FolderPaths.LocalAppData);

        //if (!Directory.Exists(FolderPaths.RoamAppData))
        //    _ = Directory.CreateDirectory(FolderPaths.RoamAppData);

        //if (!Directory.Exists(FolderPaths.ProgramFiles))
        //    _ = Directory.CreateDirectory(FolderPaths.ProgramFiles);

        //Process[] others = Process.GetProcessesByName("CheetahTerminal");
        //List<Task> tasks = [];
        //foreach (Process o in others)
        //{
        //    Task task = Task.Run(() =>
        //    {
        //        if (o.Id != Environment.ProcessId && o.StartInfo.WorkingDirectory.Equals(FolderPaths.ProgramFiles, StringComparison.Ordinal))
        //        {
        //            Log.Write($"Killing Old CheetahTerminal: pid {o.Id}");
        //            o.Kill();
        //        }
        //    });
        //    tasks.Add(task);
        //}
        //Task.WaitAll([.. tasks]);

        //CopyFolder(Environment.CurrentDirectory, FolderPaths.ProgramFiles);

        Log.Write($"Installed CheetahTerminal -> {FolderPaths.ProgramFiles}");
    }

    private void CopyFolder(string source, string target, bool overwrite = false)
    {
        if (!Directory.Exists(target))
            _ = Directory.CreateDirectory(target);

        try
        {
            foreach (string file in Directory.GetFiles(source))
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(target, fileName);
                File.Copy(file, destination, overwrite);
            }
        }
        catch (Exception e)
        {
            Log.Write(e);
        }

        try
        {
            foreach (string directory in Directory.GetDirectories(source))
            {
                string dirName = Path.GetFileName(directory);
                string destination = Path.Combine(target, dirName);
                CopyFolder(directory, destination, overwrite);
            }
        }
        catch (Exception e)
        {
            Log.Write(e);
        }
    }
}
#endif