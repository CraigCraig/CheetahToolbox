namespace CheetahToolbox.Managers;

public class ChocolateyManager(ToolboxContext context) : ManagerBase(context, "Chocolatey")
{
    private readonly List<AppEntry> apps = [];

    public string Version => NativeTerminal.Execute("choco", ["-v"]) ?? string.Empty;

    public bool IsInstalled
    {
        get
        {
            string? result = null;
            try
            {
                result = NativeTerminal.Execute("choco", ["-v"]);
                if (result != null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }

    public static void Uninstall()
    {
        // TODO: Remove Folders

        // TODO: Remove Registry Entries

        // TODO: Remove Environment Variables
    }

    public void Install()
    {
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Console.WriteLine("Must run this command as admin");
            return;
        }

        if (!IsInstalled)
        {
            Console.WriteLine("Chocolatey is not installed.");
            Console.WriteLine("Do you want to install it? Y / N: ");
            ConsoleKeyInfo input = Console.ReadKey();

            string? result = NativeTerminal.Execute("pwsh", ["-Command", "Get-ExecutionPolicy"]);
            if (!string.IsNullOrEmpty(result))
                Console.WriteLine(result);

            if (input.KeyChar is 'Y' or 'y')
            {
                string[] lines = GlobalStrings.Chocolatey.InstallCommand.Split(';');

                foreach (string line in lines)
                {
                    string cleanLine = line.Trim();
                    Console.WriteLine(cleanLine);

                    string[] args = cleanLine.Split(' ');
                    string[] args2 = args.Prepend("-Command").ToArray();

                    string? result1 = NativeTerminal.Execute("pwsh", args2);
                    Console.WriteLine(result1);
                    if (result1 == null)
                    {
                        Console.WriteLine("Chocolatey Install Failed..");
                        return;
                    }
                    else
                    {
                        if (result1.Contains("Chocolatey (choco.exe) is now ready"))
                        {
                            Console.WriteLine("Chocolatey Installed");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Chocolatey Install Failed..");
                            return;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Chocolatey Install Skipped..");
                return;
            }
        }
        Console.WriteLine("Chocolatey already installed..");
    }

    /// <summary>
    /// WIP: Check if Chocolatey result is valid.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public AppEntry? CheckResult(string line)
    {
        List<string> lines = [.. line.Split(' ')];
        if (string.IsNullOrEmpty(lines[0])) return null;
        if (lines.Count != 2) return null;

        return new AppEntry(lines[0], lines[0], null, AppEntry.AppSource.CHOCOLATEY);
    }

    /// <summary>
    /// Start the Chocolatey Manager
    /// </summary>
    public void Start()
    {
        apps.Clear();

        string? test = NativeTerminal.Execute("choco", ["list"]);
        if (test == null) return;
        List<string> tempList = [.. test.Split('\n')];
        tempList.RemoveAt(0);

        foreach (string temp in tempList)
        {
            AppEntry? item = CheckResult(temp);
            if (item != null)
                apps.Add(item);
        }
        Console.WriteLine($"Chocolatey has {tempList.Count} packages installed.");
    }
}