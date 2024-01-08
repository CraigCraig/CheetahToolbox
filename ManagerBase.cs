/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;

public abstract class ManagerBase
{
    public readonly string Name;
    public readonly ToolboxContext Context;
    public readonly Logger Log;

    public ManagerBase(ToolboxContext context, string name)
    {
        Name = name;
        Context = context;
        Log = new Logger($"{Name}");
    }
}