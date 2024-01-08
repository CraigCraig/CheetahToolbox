/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox.Commands;

[Command("Chocolatey", ["Choco"])]
public class ChocolateyCommands() : CommandBase()
{
    [Command]
    public static CommandResult Default() => new(true, "Chocolatey Helper");

    [Command]
    public static CommandResult Install()
    {
        Console.WriteLine(Localization.WorkInProgressCommand);
        return new(true, "GO GO CHOCO");
    }

    [Command]
    public class Find() : CommandBase()
    {
        [Command]
        public static CommandResult Default()
        {
            Console.WriteLine(Localization.WorkInProgressCommand);
            return new(true, "GO GO CHOCO");
        }

        [Command]
        public static CommandResult Package()
        {
            Console.WriteLine(Localization.WorkInProgressCommand);
            return new(true, "GO GO CHOCO");
        }

        [Command]
        public static CommandResult Source()
        {
            Console.WriteLine(Localization.WorkInProgressCommand);
            return new(true, "GO GO CHOCO");
        }
    }
    //public override CommandResult Execute(string? subCommand, string[] args)
    //{
    //    if (args.Length < 1)
    //        return new CommandResult(false, "invalid arguments");

    //    if (!string.IsNullOrEmpty(subCommand))
    //    {
    //        return subCommand switch
    //        {
    //            _ => new CommandResult(false, $"Unknown SubCommand: {subCommand}"),
    //        };
    //    }

    //    return new CommandResult(true);
    //}
}
#endif