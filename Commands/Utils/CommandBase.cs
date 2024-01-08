/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Commands;

public class CommandBase
{
    public CommandBase? Parent;
    public string Name { get; }
    public string Description { get; }
    public List<CommandBase>? SubCommands { get; private set; }
    public bool RootCommand;
    public readonly Logger Log;

    public CommandBase(string? name = null, string? description = null, bool subCommands = false)
    {
        Name = name ?? GetType().Name;
        Description = description ?? "No description provided.";
        if (subCommands) SubCommands = [];
        Log = new Logger($"{Name}");
    }

    public override string? ToString()
    {
        if (SubCommands == null) return $"cmd[\"{Name}\", \"{Description}\"]";
        return $"cmd[\"{Name}\", \"{Description}\"] {string.Join("|", SubCommands)}";
    }
}