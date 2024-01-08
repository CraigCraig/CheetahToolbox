#if WINDOWS
/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Applications;

/// <summary>
/// WIP: This is a placeholder for now.
/// </summary>
public class ApplicationManager : ManagerBase
{
    // TODO: Cache Locally Installed Programs
    private static readonly List<AppEntry> apps = [];

    public ApplicationManager(ToolboxContext context) : base(context, "Applications")
    {
        Log.Write($"Application Manager");
    }

    private static AppEntry? GetApp(string path)
    {
        if (!Directory.Exists(path)) return null;

        try
        {
            string[] files = Directory.GetFiles(path, "*.exe", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                // WIP: Cache AppEntry
                return new AppEntry(Path.GetFileNameWithoutExtension(file), null, null, file, AppEntry.AppSource.LOCAL);
            }
            return null;
        }
        catch /*(UnauthorizedAccessException ex)*/
        {
            // TODO: Abort and request admin
            // Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    private static void ScanAppFolder(string path)
    {
        AppEntry? app = GetApp(path);
        if (app == null) return;
        apps.Add(app);
    }

    public static void Scan()
    {
        Console.WriteLine("Application Manager Scanning..");
        Stopwatch sw = Stopwatch.StartNew();

        string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
        //Console.WriteLine($"Start Menu Path: {startMenuPath}");

        string startMenuPath2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms);
        //Console.WriteLine($"Start Menu Path 2: {startMenuPath2}");

        string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        //Console.WriteLine($"Program Data Path: {programDataPath}");

        List<string> programDataFilesDirs = [.. Directory.GetDirectories(programDataPath)];
        foreach (string dir in programDataFilesDirs)
        {
            //Console.WriteLine($"\tProgram Data Directory: {dir}");
            ScanAppFolder(dir);
        }

        string commonPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
        //Console.WriteLine($"Common Program Files Path: {commonPath}");

        List<string> commonFilesDirs = [.. Directory.GetDirectories(commonPath)];
        foreach (string dir in commonFilesDirs)
        {
            //Console.WriteLine($"\tCommon Program Directory: {dir}");
            ScanAppFolder(dir);
        }

        string commonPathX86 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
        //Console.WriteLine($"Common Program X86 Files Path: {commonPathX86}");

        List<string> commonFilesX86Dirs = [.. Directory.GetDirectories(commonPathX86)];
        foreach (string dir in commonFilesX86Dirs)
        {
            //Console.WriteLine($"\tCommon Program X86 Directory: {dir}");
            ScanAppFolder(dir);
        }

        string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        //Console.WriteLine($"Program Files Path: {programPath}");

        List<string> programFilesDirs = [.. Directory.GetDirectories(programPath)];
        foreach (string dir in programFilesDirs)
        {
            //Console.WriteLine($"\tProgram Directory: {dir}");
            ScanAppFolder(dir);
        }

        string programPathX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        //Console.WriteLine($"Program X86 Files Path: {programPathX86}");

        List<string> commonFilesDirsX86 = [.. Directory.GetDirectories(commonPathX86)];
        foreach (string dir in commonFilesDirsX86)
        {
            //Console.WriteLine($"\tCommon Program X86 Directory: {dir}");
            ScanAppFolder(dir);
        }

        sw.Stop();
        Console.WriteLine($"Cached: {apps.Count} Applications: {sw.ElapsedMilliseconds}ms");
    }
}
#endif