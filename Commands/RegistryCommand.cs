/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================

//#if WINDOWS
//namespace CheetahToolbox.Modules.Core.Commands;

//using Attributes;
//using global::CheetahToolbox.Commands;

//[Group("Registry Tweaks/Cleaning/Repair")]
//public class RegistryCommand(ModuleBase module) : CommandBase(module, "registry", "Registry Tweaks/Cleaning/Repair")
//{
//    [Command("display info")]
//    public void Info() => Console.WriteLine("test");

//    public override CommandResult Execute(string? subCommand, string[]? args)
//    {
//        if (string.IsNullOrEmpty(subCommand)) return new CommandResult(false, "No argument provided"); // TODO: Add sub help

//        switch (subCommand)
//        {
//            case "reset":
//                return new CommandResult(false, "WIP: Command coming soon..");
//            case "tweak":

//                break;
//            default:
//                return new CommandResult(false, "Invalid argument");
//        }

//        return new CommandResult(true);
//    }
//}
//#endif