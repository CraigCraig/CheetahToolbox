/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;

using Exceptions;
using Commands;
using Packages;

public class CheetahToolbox
{
    public readonly ToolboxContext Context;
    public readonly Logger Log;

    public Version ToolboxVersion;

    public CheetahToolbox(List<string> args)
    {
        ToolboxVersion = typeof(CheetahToolbox).Assembly.GetName().Version ?? throw new VersionNotFoundException();
        Log = new Logger("CheetahToolbox");
        Context = new(this);

        if (args.Count > 0)
        {
            string command = args[0];

            // Handle Settings Flags
            foreach (string arg in args)
            {
                switch (command)
                {
                    case "-d":
                        Console.WriteLine("Debug Mode");
                        break;
                    default:
                        break;
                }
            }

            switch (command)
            {
                case "-v":
                    Console.WriteLine(ToolboxVersion);
                    break;
                case "-c":
                    Console.WriteLine("Coming soon");
                    break;
                case "-clsid":
                    if (args.Count > 1)
                    {
                        Type? test = Type.GetTypeFromCLSID(Guid.Parse(args[1]));
                        if (test == null)
                        {
                            Console.WriteLine("Failed");
                            return;
                        }
                        Console.WriteLine($"CLSID: {test.FullName}");
                        //object? test2 = Activator.CreateInstance(test);
                    }
                    else
                    {
                        Console.WriteLine("Failed: No ID Provided");
                    }
                    break;
                case "-s":
                    string? result = TerminalUtils.Cmd("pwsh get-AppxPackage");
                    Console.WriteLine(result);
                    break;
                case "-u":
                    Context.Packages.Update();
                    break;
                default:
                    break;
            }
            return;
        }

        Version version = typeof(CheetahToolbox).Assembly.GetName().Version ?? throw new VersionNotFoundException();
        Log.Write($"CheetahToolbox v{version}");

#if WINDOWS
        if (ChocolateyManager.IsInstalled)
        {
            Log.Write($"Chocolatey v{ChocolateyManager.Version}");
        }

        if (ScoopManager.IsInstalled)
        {
            Log.Write($"Scoop {ScoopManager.Version}");
        }

        if (WingetManager.IsInstalled)
        {
            Log.Write($"Winget {WingetManager.Version}");
        }
#endif

        while (true)
        {
            Console.Write(Prompt.Build(Context));
            string? line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line))
            {
                string[] split = line.Split(' ');
                string command = split[0];
                string[] arguments = split[1..];

                CommandResult? result = Context.Commands.HandleCommand(command, arguments);
                if (result == null) break;

                Log.Write(result.Message);
            }
        }
    }
}