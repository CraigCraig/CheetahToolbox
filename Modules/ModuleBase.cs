/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Modules;

using Commands;

/// <summary>
/// Base class for all modules.
/// </summary>
/// <param name="name"></param>
/// <param name="description"></param>
public class ModuleBase(ToolboxContext context, string name, string description)
{
    public ToolboxContext Context { get; private set; } = context;
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public List<CommandBase> Commands { get; private set; } = [];
}