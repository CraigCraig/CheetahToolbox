/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Commands;

[Command("Console", null, "Console Commands")]
public class ConsoleCommands() : CommandBase()
{
    [Command("Clear", ["Clr"], "Clear the console")]
    public static CommandResult? Clear()
    {
        Console.Clear();
        return new CommandResult(true);
    }
}