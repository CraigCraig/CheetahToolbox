namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class HelpCommand(ModuleBase module) : CommandBase(module, "help", "this menu")
{
    public override CommandResult Execute(string? subCommand, string[]? args)
    {
        StringBuilder sb = new();
        foreach (ModuleBase module in Module.Context.Modules.Modules)
        {
            _ = sb.Append($"Module: {module.Info.Name}{Environment.NewLine}");

            foreach (CommandBase command in module.Commands)
            {
                _ = sb.Append($"\tCommand: {command.Name}");
            }
        }

        return new CommandResult(true, sb.ToString());
    }
}