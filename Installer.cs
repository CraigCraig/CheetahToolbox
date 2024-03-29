/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

using Modules;

public class Installer : ModuleBase
{
    public override string Name { get; set; } = "Installer";

    public override string[] Aliases { get; set; } = ["install"];

    public override string Description { get; set; } = "Installer Module";

    public override void Initialize()
    {
    }

    public override void Execute(string command, string[] args)
    {
        Console.WriteLine("Success");
    }
}