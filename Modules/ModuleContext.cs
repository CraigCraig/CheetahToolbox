/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Modules;

public class ModuleContext : ToolboxContext
{
    public ModuleContext(CheetahToolbox toolbox, ModuleBase module) : base(toolbox)
    {
        Console.WriteLine($"ModuleContext: {GetType().FullName}");
    }
}